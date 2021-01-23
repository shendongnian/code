        while(0 != 1)
        {
            list.Add(a);
            charCount = a.ToString().Length;
            if (charCount >= 1000)
            {
                Console.WriteLine(list.IndexOf(a));
                break;
            } 
            BigInteger c = a;   //
            a = b;              // this is the Fibonacci sequence
            b = a + c;          //
        }
