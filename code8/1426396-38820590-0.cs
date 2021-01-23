    private void saveButton_Click(object sender, EventArgs e)
    {
        List<List<string>> data = new List<List<string>>();
        foreach(DataGridViewRow row  in dgInsertedInfo.Rows)
        {
           List<string> rowData = new List<string>();
           foreach (DataGridViewCell cell in row.Cells)
               rowData.Add(cell.FormattedValue.ToString());
           data.Add(rowData);
        }
        XmlSerializer xs = new XmlSerializer(data.GetType());
        TextWriter tw = new StreamWriter(yourFileName);
        xs.Serialize(tw, data);
        tw.Close(); 
    }
    private void loadButton_Click(object sender, EventArgs e)
    {
        List<List<string>> data = new List<List<string>>();
        XmlSerializer xs = new XmlSerializer(data.GetType());
        TextReader tr = new StreamReader(yourFileName);
        data = (List<List<string>>) xs.Deserialize(tr);
        foreach (List<string> rowData in data)
            dgInsertedInfo.Rows.Add(rowData.ToArray());
    }
