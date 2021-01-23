       try
                {
                    String str = txtemailid.Text;
                    String[] name = str.Split('@');
    
                    if (name.Count() == 2)
                    {
                        llbMsg.Text = "Entered Email" + name[0].ToString() + "Incorrect";
                    }
                    else
                    {
                        llbMsg.Text = "Entered Email" + name[0].ToString() + "Correct";
                    }
                    
                }
                catch { }
