    StringBuilder sb = new StringBuilder();
    for (int i=0; i< listView1.Items.Count; i++)
    {
        if (listView1.Items[i].SubItems[1].Text == "Inactive")
        {
            sb.AppendFormat("{0} inactive on {1}{2}", listView1.Items[i].Text,lbl_time.Text,Environment.NewLine);
        }
    }
    richTextBox.Text = sb.ToString();
    string path = System.IO.Path.Combine(Application.StartupPath, "MyFile.txt");
    File.WriteAllText(path,richTextBox.Text);
