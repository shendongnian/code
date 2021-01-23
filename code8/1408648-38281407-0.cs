    using (StreamWriter writer = new StreamWriter(@"C:\values.ini", true))
    {
        foreach (string key in values.Keys)
        {
            if (values[key] != string.Empty)
            {
                int hex;
                if(int.TryParse(values[key], System.Globalization.NumberStyles.HexNumber, out hex))
                {
                    writer.WriteLine("{1}", key, hex);
                }
                else
                {
                    //Replace this line with your error handling code.
                    writer.WriteLine("Failed to convert {1}", key, values[key]);
                }
            }
        }
    }
