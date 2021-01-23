    StringBuilder ab = new StringBuilder();                
    for (int i = 0; i < methArr.Length; i++)
    {
        
        ab = ab.AppendLine(methArr[i].ToString());
        listBox1.Items.Add(ab.ToString());
        ab.Clear();
    }
