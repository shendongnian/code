        [TestMethod]
        public void ProcessBots()
        {
            string[] bots = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            IProgress<string> progress = new Progress<string>(str =>
            {
                this.TestContext.WriteLine(str);
            });
            Parallel.ForEach(bots, bot =>
            {
                progress.Report(bot);
            });
            Parallel.For(0, bots.Length, i =>
            {
                progress.Report(i.ToString());
            });
        }
