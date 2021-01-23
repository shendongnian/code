    bool writeON = false;
    StringBuilder sb = new StringBuilder();
    foreach (char c in line)
    {
        if (c == '>')
            writeON = true;
        else  if (c == '<')
        {
            writeON = false;
            if (sb.Length > 0)
                Debug.WriteLine(sb.ToString());
            sb.Clear();
        }
        else if (writeON)
            sb.Append(c);
    }
    Debug.WriteLine("ddonce");
