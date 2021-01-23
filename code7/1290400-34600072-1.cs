    private void runSync(object sender, EventArgs e)
    {
        //I can see the value of count is 2 when using break points
        List<string> vals = repo.getRemovedAnswers();
        for (int i = vals.Count() - 1; i >= 0; i--)
        {
            repo.setAnswerDeleted(vals.ElementAt(i));
            Console.WriteLine(i + " removed");
        //
        }              
        Console.WriteLine("syncing");
    }
