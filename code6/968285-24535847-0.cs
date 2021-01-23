     public void SetControl(string ControlName, string Operation)
        {
            Control Control = this.Controls.Find(ControlName, true)[0];
            if (Operation=="Green")
            {
                Control.BackColor = Color.LimeGreen;
                Control.ForeColor = SystemColors.ControlText;
            }
        }
