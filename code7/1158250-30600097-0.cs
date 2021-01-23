    foreach (string myLine in A)
    {
	       if (myLine.Contains("Savings found:") == true)
           {
                Console.WriteLine(myLine);
           }
           if...(further code to deal with 30%+ savings, etc...)
           {
                Console.WriteLine(myLine + "*");
           }
    }
