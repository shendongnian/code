    private void button6_Click(object sender, EventArgs e)
    {
        string copyPath = @"C:\user\elec\copy";
        if (!System.IO.Directory.Exist(copyPath))
             System.IO.Directory.Create(copyPath);   
        for (int i=0; i< dataGridView1.Rows.Count; i++)
        {
            if(!String.IsNullOrEmpty(dataGridView1.Rows[i].Cell[0].Value.ToString()))
            {            
                string filePath = dataGridView1.Rows[i].Cells[0].Value
                If (System.IO.File.Exists(filePath))
                { 
                    dataGridView1.Rows[i].Cells[1].Value = filePath;
                    string fileName  =  Path.GetFileName(filePath);
                    string newpath = Path.Combine(copyPath,fileName);
                    System.IO.File.Copy(filePath, newpath, true);
                }
                dataGridView1.row.Cells[0].Value = string.Empty;
            }
        }
    }
