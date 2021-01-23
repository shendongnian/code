    foreach(Control c in this.Controls)
                    {
                        if(c is Label)
                        {
                            Label b = c as Label;
                            b.ForeColor = Color.White;
                        }
                    }
