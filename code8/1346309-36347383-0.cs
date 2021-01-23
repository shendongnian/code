    foreach(Control t in Ratingfields)
            {
                if (t.Enabled == false)
                {
                    t.BackgroundImage = Image.FromFile("M:\\DisableBox_18x.png");
                    t.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    if (((CheckBox)t).Checked == true)
                    {
                            t.BackgroundImage = Image.FromFile("M:\\RadioGreen_Disabled18x.png");
                            t.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                        }
                }
            }
