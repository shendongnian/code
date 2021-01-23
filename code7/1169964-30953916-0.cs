    public void MainMenuButton(bool createButton, Form form)
    {
        if (createButton)
        {
            System.Windows.Forms.Button StartB = new System.Windows.Forms.Button();
            form.Controls.Add(StartB);
            StartB.Text = "Start";
            StartB.Top = 300;
            //StartB.Bottom = 100;
            StartB.Left = 400;
        }
        else
        {
            //  this.Controls.Remove(StartB);
        }
    }
