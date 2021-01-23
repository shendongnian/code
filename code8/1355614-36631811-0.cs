    using Color = System.Drawing.Color;
    ...
    {
        string input = $"#ff{myTextBox.Text}"; // let the user enter just the digits 
        
        input = input.ToLower(); // Needs to be lowercase
        string name;
        KnownColor[] values = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        for(int i =0; i <values.Length; i++)
        {
            if (i <= 25 || i >= 167) continue; // Eliminate default wpf control colors
            int RealColor = Color.FromKnownColor(values[i]).ToArgb();
            string ColorHex = $"{RealColor:x6}";
            if ($"#{ ColorHex }"== input)
            {
                name = values[i].ToString();
                break;
            }
        }
    }
