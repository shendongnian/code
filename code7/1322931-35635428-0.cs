    private async void MainForm_Load(object sender, EventArgs e)
    {    //Hide all buttons
        button1.Visible = false;
        button2.Visible = false;
        button3.Visible = false;
        await Task.Delay(500);
       //show buttons one by one
        button1.Visible = true;
        await Task.Delay(500);
        button2.Visible = true;
        await Task.Delay(500);
        button3.Visible = true;
    }
