    for (int i = 0; i < 8; i++)
           {   
              foreach (Control c in Form1.Controls)
                    {
                       if (c is Button)
                         {
                           Button btn  = (c as CheckBox);
                            if (Convert.ToInt32(btn.Tag) == address * 8 + i)
                             {
                              if ((led_stat & 1) == 1)
                                {
                                    btn.Appearance.BackColor = Color.Green;
                                }
            
                                else
                                {
                                    btn.Appearance.BackColor = Color.Red;
                                }
                            }
                            }
                        }
            led_stat >>= 2;
                }
        
                return;
