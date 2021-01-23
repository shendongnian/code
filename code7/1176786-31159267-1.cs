    StringBuilder sb = new StringBuilder();
    sb.Append("Ola");
    sb.Append("Jola");
    sb.Append("Zosia");
    for (int i = 0; i < sb.Length; i++)
    {
        char c = sb[i];
        if (Char.IsUpper(c)) Console.Write('\n');
        Console.Write(c);
    }
