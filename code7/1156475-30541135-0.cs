    private void button1_Click(object sender, EventArgs e)
    {
        listView1.Items.Clear();
        listView1.Refresh();
        string[] filePaths = Directory.GetFiles(@textBox1.Text, "*.zip");
        string txtSearch = textBox2.Text;
        bool found = false;
        foreach (var filePath in filePaths)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    var position = entry.Name.IndexOf(txtSearch, StringComparison.InvariantCultureIgnoreCase);
                    if (position > -1)
                    {
                        found = true;
                        listView1.Items.Add(entry.Name);
                        break;      // Comment out this line if you want more results from a single zip file
                    }
                }
            }
        }
        if (!found)
        {
            MessageBox.Show("File not found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
