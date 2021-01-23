    private void ClearError()       
            {
                
                foreach (Control cn in this.Controls)
                {
                    
                    err.SetError(cn,"");
                  
                    err.Clear();
                    cn.BackColor = Color.White;
    
                }
            }
