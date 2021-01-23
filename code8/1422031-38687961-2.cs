    Form f2 = new Form();
    private void button1_Click(object sender, EventArgs e)
    {
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.IsMdiContainer = true;            
        //Form f2 = new Form(); To prevent creating a new form everytime.
        f2.MdiParent = this;
        f2.StartPosition = FormStartPosition.CenterScreen;
        f2.Show();
    }
