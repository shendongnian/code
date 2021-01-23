    private void Form1_Load(object sender, System.EventArgs e)
    {
        string[] s = null;
        clsConn.prdType PRD = new clsConn.prdType();
         s = returndata.Split('|');
    
        listBox1.Items.AddRange(s);
    }
