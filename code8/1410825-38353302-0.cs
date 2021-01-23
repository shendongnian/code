    private void oTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["anytext_Form"];
        f.xdatetxt.Text=System.DateTime.Now.ToString();
    }
