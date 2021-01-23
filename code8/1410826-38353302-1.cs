    private void oTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        dynamic f = System.Windows.Forms.Application.OpenForms["anytext_Form"];
        f.xdatetxt.Text=System.DateTime.Now.ToString();
    }
