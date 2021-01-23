    public void MainMenuButton(bool createButton, Form form)
    {
        if (createButton)
        {
            System.Windows.Forms.Button startB = new System.Windows.Forms.Button();
            form.Controls.Add(startB);
            startB.Text = "Start";
            startB.Top = 300;
            //startB.Bottom = 100;
            startB.Left = 400;
        }
        else
        {
            //  this.Controls.Remove(startB);
        }
    }
