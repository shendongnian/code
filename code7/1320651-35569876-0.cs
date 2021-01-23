    using (StreamReader sr = new StreamReader(a))
    {
    
        while ((line1 = sr.ReadLine()) != null)
        {
            Console.WriteLine("Value in the first file is :"+line1);
              x = Convert.ToInt32(line1);
              sum += x;
        }
    }
    using (StreamReader sr = new StreamReader(b))
    {
    
        while ((line2 = sr.ReadLine()) != null)
        {
            Console.WriteLine("Value in the second file is :" + line2);
            y = Convert.ToInt32(line2);
            sum += y;
        }
    }
