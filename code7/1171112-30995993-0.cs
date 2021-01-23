    var dict = new Dictionary<string, int>();
    while (serialPort1.IsOpen)
    {
        string[] number = RxString.Split(' ');
        string unit = number[1];
        if (dict.ContainsKey(unit))
        {
            dict[unit]++;
            if (dict[unit] == 4)
            {
                 // execute some parameters
            }
        }
        else
        {
            dict.Add(unit, 1);
        }
    }
