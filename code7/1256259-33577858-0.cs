    DateTime Time = DateTime.Now;
    string format = "ddd";
    Console.WriteLine(Time.ToString(format));
    string day = Time.ToString(format);
    if (day = "Mon; Tue; Wed; Thu; Fri;") 
    {
        Console.WriteLine("It is a week day");
    }
    else
    {
        Console.WriteLine("it is a weekend");
    }
