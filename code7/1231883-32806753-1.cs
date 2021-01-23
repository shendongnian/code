    var sb = new StringBuilder();
    
    string story = sb.Append("Critical error occurred after ")
                   .Append(elapsed.ToString("hh:mm:ss"))
                   .AppendLine()
                   .AppendLine()
                   .Append(exception.Message)
                   .ToString();
    File.WriteAllText(path, story);
