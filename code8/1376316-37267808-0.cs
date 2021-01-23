            Label[] lbl ;
            
            private void setupControls()
            {
                int Totallbl = 5;
                int height = 30;
                lbl = new Label[Totallbl];
                try
                {
                    for (int i = 0; i < Totallbl; i++)
                    {
                        lbl[i] = new Label();
                        lbl[i].Location = new Point(20, ((i + 1) * height));
                        lbl[i].Name = "lbl" + i;
                        lbl[i].Text = "LabelText";
                        lbl[i].AutoSize = true;
                        this.Controls.Add(lbl[i]);
                    }
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                }
            }
