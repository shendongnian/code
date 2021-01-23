     protected void btnSubmit_Click(object sender, EventArgs e)
            {
                UpdatePanel ImageUpdatePanel = (UpdatePanel)this.Parent.FindControl("up");
               
                Image _img = (Image)ImageUpdatePanel.FindControl("Image1");
             
                _img.Visible = true;
                //Updating UpdatePanel
                ImageUpdatePanel.Update();
            }
