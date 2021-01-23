    private void button1_Click(object sender, EventArgs e)
    {
        listView1.Items.Clear();
        listView1.Refresh();
        string[] filePaths = Directory.GetFiles(@textBox1.Text, "*.zip");
        string txtSearch = textBox2.Text;
        var foundEntries = new List<string>();
        foreach (var filePath in filePaths)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                foundEntries = archive.Entries
                    .Where(e => e.Name.IndexOf(txtSearch, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    .Select(e => e.Name);
                if (foundEntries.Any())
                {
                    listView1.Items.AddRange(foundEntries);
                }
                else
                {
                    MessageBox.Show("FILE NOT FOUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            foundEntries.Clear();
        }
    }
