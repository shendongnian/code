    using (StreamReader sr = new StreamReader(a))
    using (StreamReader sr = new StreamReader(b))
    {
       while ((line1 = sr.ReadLine()) != null && (line2 = sr.ReadLine()) != null)
       {
           Console.WriteLine("Value in the first file is :"+line1);
           Console.WriteLine("Value in the second file is :" + line2);
           x = Convert.ToInt32(line1);
           y = Convert.ToInt32(line2);
           Console.WriteLine("values are :" + line1, line2);
           Console.WriteLine("values are :" + x, y);
           sum = x + y;
           Console.WriteLine("The sum of values in both the file is :" + sum);
       }
