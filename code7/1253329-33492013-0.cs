    public void read(string destinination)
    {
        Form1 f1 = new Form1();
        StreamReader sw = File.OpenText(destinination);
        string s = "";
        ListView1.Item.Clear();
        try
        {
            while ((s = sw.ReadLine()) != null)
            {
                string[] words = s.Split('*');
                ListViewItem lv = new ListViewItem(words[0].ToString());
                lv.SubItems.Add(words[1].ToString());
                lv.SubItems.Add(words[2].ToString());
                listView1.Items.Add(lv);
            }
        }
        catch ( Exception ex)
        {
            Console.WriteLine(ex);
        }
        sw.Close();
    }
