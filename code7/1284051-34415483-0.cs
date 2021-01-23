        [TestMethod]
        public void ProcessBots()
        {
            string[] bots = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            Parallel.ForEach(bots, bot => //use if you just want to foreach
            {
                this.TestContext.WriteLine(bot);
            });
            Parallel.For(0, bots.Length, i => //use if you care about the index
            {
                this.TestContext.WriteLine(i.ToString());
            });
        }
    Test Name:	ProcessBots
    Test Outcome:	Passed
    Result StandardOutput:	
    TestContext Messages:
    A
    D
    E
    F
    G
    B
    C
    0
    2
    3
    4
    5
    1
    6
