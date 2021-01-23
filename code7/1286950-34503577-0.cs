    private void ReadAllLines()
    {
        using (StreamReader reader = new StreamReader(inputFile))
        {
            reader.ReadLine(); // skip first line
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                waitInput.WaitOne(); // wait for user input
                // Do your stuff...
            }
        }
    }
