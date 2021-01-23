    foreach (char ch in name)
    {
        int decNumber = ch;
        Console.WriteLine(decNumber);                
        for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine("Enter a number:");
                int a = Convert.ToInt32(Console.ReadLine());
                var result = Convert.ToString(a, 2);
                Console.WriteLine(result);
            }             
    }
