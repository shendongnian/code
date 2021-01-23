    // e.g whereas you had:
    StringBuilder sb = new StringBuilder();
    sb.Append("Ola");
    sb.Append("Jola");
    sb.Append("Zosia");
    // the scenario will only work if you did the following:
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("Ola");
    sb.AppendLine("Jola");
    sb.AppendLine("Zosia");
    // you can split your strings as follows:
    string[] resultLines = TestResultStr.ToString().Split(new char[] { '\n', '\r' });
    for (int i = 0; i < resultLines.Length; i++)
    {
	    Console.WriteLine(resultLines[i]);
    }
