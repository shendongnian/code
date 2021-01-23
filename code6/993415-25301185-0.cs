    bool matched = false;
    foreach (char c in alphabet)
    {
        m = Regex.Match(s, @"\d{3}(?=[" + c + "-]|$)");
        if (m.Success)
        {
            int i = Convert.ToInt32(m.Value); i += 1;
            Console.WriteLine(s + " - " + i.ToString("D3"));
            matched=true;
            break;
        }
    }
    if(!matched)
        Console.WriteLine(s + " - No success");
