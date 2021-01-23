    var dict = new Dictionary<string, int?>();
    while (serialPort1.IsOpen)
    {
        string[] number = RxString.Split(' ');
        string unit = number[1];
        if (dict.ContainsKey(unit))
        {
            if (dict[unit].HasValue)
            {
                dict[unit]++;
                if (dict[unit] == 4)
                {
                    // execute some parameters
                    dict[unit] = null;
                }
            }
        }
        else
        {
            dict.Add(unit, 1);
        }
    }
