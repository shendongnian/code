    for (int i = 1; i < 9; i++)
                {
                    var enabledbox = this.Controls.Find("textbox" + i, true);
                    foreach (TextBox enabledbox1 in enabledbox)
                    {
                        if (enabledbox1.Enabled == true)
                        {
                            //do something
                        }
                    }
                }
