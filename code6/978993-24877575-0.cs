    private void button1_Click(object sender, EventArgs e)
    {
        var processes = Process.GetProcesses();
        foreach (ListViewItem item in this.listView1.Items)
        {
            item.SubItems[1].Text = ((processes.Any(p => p.ProcessName == item.SubItems[0].Text)
                                        ? "ACTIVE"
                                        : "INACTIVE"));
        }
    }
