    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
                {
        
                    int st = dtpreturndate.Value.Date.Subtract(dtpduedate.Value.Date).Days;
        
                    if ((st > 0))
                    {
                        txtfine.Text = ((st * 5)).ToString();
                    }
                    else
                    {
                        txtfine.Text = "0";
                    }   
        
                }
