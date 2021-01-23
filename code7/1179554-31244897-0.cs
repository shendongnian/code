    void btnGetProcesses_Click(object sender, EventArgs e)
    {
        Process[] processes = Process.GetProcesses();
        ListViewItem lstViewItems = null;
        foreach (Process process in processes)
        {
            lstViewItems = new ListViewItem();
            lstViewItems.Text=process.Id.ToString();
            lstViewItems.SubItems.Add(process.ProcessName);
            lstViewItems.SubItems.Add(process.StartTime.ToString());
            listView1.Items.Add(lstViewItems);
        }
    }
