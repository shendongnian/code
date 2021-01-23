    var results = questions.GroupJoin(answers,
        s => questions,
        s => Observable.Empty<int>(),
        (q, a) => new { Question = q, Answers = a });
    results2
        .Subscribe(i => 
        {
            Console.WriteLine(string.Format("{0}", i.Question));
            i.Answers.Subscribe(a => Console.WriteLine("  {0}", a));
        });
