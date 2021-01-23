     foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox ck = (c as CheckBox);
                        if (ck.Checked)
                        {
                            MessageBox.Show("Check " + ck.Text + " is chcked");
                        }
                    }
                }
