        Dictionary<string, int> dic = new Dictionary<string, int>();
        string item = null;
        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
        {
                item = dataGridView1.Rows[i].Cells[1].Value.ToString();
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                }
                else
                {
                    dic[item] += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                }
            
        }
    
