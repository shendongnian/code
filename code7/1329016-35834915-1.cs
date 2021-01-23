    var lines = File.ReadAllLines(@"F:\testdata.hrm").Skip(1);
    List<string[]> list = new List<string[]>();
    foreach (var line in lines)
    {
        list.Add(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }
    for (int i = 0; i < 6; i++)
    {
        List<string> cols = new List<string>();
        for (int j = 0; j < list.Count; j++)
        {
            cols.Add(list[j][i]);
        }
        dataGridView1.Rows.Add(cols.ToArray());
    }
