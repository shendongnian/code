    public void ButtonClick(object sender, EventArgs e)
    {
        var myControl = new MyUserControl();
        var form = new Form1(myControl);
        form.Show();
    }
