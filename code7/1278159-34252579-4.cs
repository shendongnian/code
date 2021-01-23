    private void ShowUserControl_Click(object sender, EventArgs e)
    {
        foreach(UserControl uc in UserControls)
        {
            if(uc.Name == (string)((Control)sender).Tag)
            {
                previous = current;
                uc.Visible = true;
                current = uc;
            }
            else
            { 
                uc.Visible = false;
            }
        }
    }
    
    private void ShowPrevControl_Click(object sender, EventArgs e)
    {
        if (previous != null) 
        {
            foreach(var uc in UserControls)
            {
                uc.Visible = false;
            }
            var temp = current;
            previous.Visible = true; 
            current = previous;
            previous = temp; 
        }
    }
