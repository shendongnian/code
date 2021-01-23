     private void btnCheckNumbs_Click(object sender, EventArgs e)
            {
                var list = new List<TextBox>();
                //Check to see what numbers have been called by calling on Global Variables. 
                for (int i = 1; i <= Globals.NextBalls; i++)
                {
                    for (int k = 1; k <= 90; k++)
                    {
                        if (Globals.balls[i] == k)
                        {
                            TextBox txtName = (TextBox) this.Controls.Find("txtBoxs" + k.ToString(), true)[0];
                            list.Add(txtName);
                        }
                    }
                }
            list.Last().BackColor = Color.Crimson;
            }
