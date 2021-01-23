        int incmount = 0;
        List<int> items = new List<int>();
        int numofit = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < numofit; i++)
        {
            items.Add(incmount);
            incmount++;
        }
        Console.WriteLine("Number of items: {0}", items.Count);
