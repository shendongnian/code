    string tmpstr = "New,Open,Exit,Copy,Cut,Paste,Help,About,";
    string tmpnumstr = "3,3,2,"; // string of numbers;
    string[] items = tmpstr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    int[] itemSequence = tmpnumstr
        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(x => Convert.ToInt32(x))
        .ToArray();
    var sb = new StringBuilder();
    var batchingProcessor = new BatchingProcessor<string>(items);
    foreach (int itemCount in itemSequence)
    {
        var batch = batchingProcessor.Take(itemCount);
        foreach (string item in batch.Values)
        {
            sb.Append(item);
            sb.Append(",");
        }
        sb.AppendLine();
        if (batch.EndReached)
        {
            // tmpnumstr specifies more strings than tmpstr contains.
            break;
        }
    }
    textBox1.Text = sb.ToString();
