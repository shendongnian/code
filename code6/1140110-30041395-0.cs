    private void NDokButton_Click(object sender, EventArgs e)
    {
        //You're creating a new main form here.  You need an instance of the existing form.
        MainForm mf = new MainForm();
        DataTable dt = mf.GetData();
        var n = dt.Rows[0].ItemArray[0];
        String a = n.ToString();
        MessageBox.Show(a);
    }
