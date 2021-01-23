    string tmpstr = "New,Open,Exit,Copy,Cut,Paste,Help,About,";
    string tmpnumstr = "3,3,2,"; // string of numbers;
    string[] items = tmpstr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    int[] itemSequence = tmpnumstr
        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(x => Convert.ToInt32(x))
        .ToArray();
    var batchingProcessor = new BatchingProcessor<string>(items);
    var groups = itemSequence
        .Select(itemCount => batchingProcessor.Take(itemCount))
        .Select(batch => string.Join(",", batch.Values))
        .ToArray();
    textBox1.Text = string.Join("," + Environment.NewLine, groups);
