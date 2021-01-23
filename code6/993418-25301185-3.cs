        m = Regex.Match(s, @"\d{3}(?=[A-Z\-]|$)");
        if (m.Success)
        {
            int i = Convert.ToInt32(m.Value); i += 1;
            Console.WriteLine(s + " - " + i.ToString("D3"));
        }
        else
           Console.WriteLine(s + " - No success");
