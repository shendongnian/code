     private void buttonVisibility()
        {
            if (lblUserType.Text == "special_user")
            {
                txtDisc.Visible = true;
                lblLock.Visible = false;
            }
           else
           {
               txtDisc.Visible = false;
                lblLock.Visible = true;
           }
        }
