    string input = "My=Steve,My=Myland";
    
    StringBuilder sb = new StringBuilder();
    string[] parts = input.Split(',');
    foreach (string p in parts)
    {
        string[] subs = p.Split('=');
        sb.Append(subs[1] + ".");
    }
    if(sb.Length > 0) sb.Length--;
    Console.WriteLine(sb.ToString());
