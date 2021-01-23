    private void Form1_Load(object sender, EventArgs e)
    {
        timer3.Start();
    }
    private void InactiveCheck()
    {
        for (int i = 0; i < listView1.Items.Count; i++)
        {
            if (listView1.Items[i].SubItems[1].Text == "Inactive")
            {
                richTextBox1.Text = richTextBox1.Text + listView1.Items[i].Text + " was inactive at " + DateTime.Now.ToString("hh':'mm tt") + "\n";
                File.AppendAllText(@"C:\Documents and Settings\pamojica\My Documents\InactiveProgramLogs\" + lbl_date.Text + ".txt", richTextBox1.Text);               
            }
            else
            {
                timer3.Start();
            }
        }
    }
    private void timer3_Tick(object sender, EventArgs e)
    {
        timer3.Stop()
        InactiveCheck();
    }
