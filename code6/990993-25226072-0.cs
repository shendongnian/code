    foreach (Control ctrl in this.flowLayoutPanel1.Controls)
                {
                    foreach (Control item in ctrl.Controls.Find("button1", true))
                    {
                        Point pointOnForm = new Point(0, 0);
                        Control Btn = item;
                        for (; Btn.Parent != null && Btn.Parent.GetType() != typeof(Form); Btn = Btn.Parent)
                        {
                            pointOnForm.Offset(Btn.Location);
                        }
                        //label2.Text += pointOnForm + ",";
                    }
                }
