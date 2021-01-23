    for (int i = 0; i < methArr.Length; i++)
    {
        StringBuilder ab = new StringBuilder();    
        ab = ab.AppendLine(methArr[i].ToString());
        listBox1.Items.Add(ab);
    }
