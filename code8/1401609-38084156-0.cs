     public async Task SampleChain_Quiz()
        {
            var quiz = Chain
                .PostToChain()
                .Select(_ => "how many questions?")
                .PostToUser()
                .WaitToBot()
                .Select(m => int.Parse(m.Text))
                .Select(count => Enumerable.Range(0, count).Select(index => Chain.Return($"question {index + 1}?").PostToUser().WaitToBot().Select(m => m.Text)))
                .Fold((l, r) => l + "," + r)
                .Select(answers => "your answers were: " + answers)
                .PostToUser();
            using (var container = Build(Options.ResolveDialogFromContainer))
            {
                var builder = new ContainerBuilder();
                builder
                    .RegisterInstance(quiz)
                    .As<IDialog<object>>();
                builder.Update(container);
                await AssertScriptAsync(container,
                    "hello",
                    "how many questions?",
                    "3",
                    "question 1?",
                    "A",
                    "question 2?",
                    "B",
                    "question 3?",
                    "C",
                    "your answers were: A,B,C"
                    );
            }
        }
