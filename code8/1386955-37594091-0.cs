    private void btnSearch_Click(object sender, EventArgs e)
        {
            const string index = @"items.lst";
            string[] search = System.IO.File.ReadAllLines(index);
            string[] sep = {"\r\n"};        
            foreach (string item in search)
            {
                var myitem = lines.Cast<string>().Where(i => item.Contains(i)).FirstOrDefault();
                if (myitem != null && myitem.Trim().Length > 0)
                    listView1.Items.Add(myitem + Environment.NewLine);
                
            }
        }
