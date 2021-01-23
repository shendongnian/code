    if (tpos < 0)
                    {
                        MessageBox.Show("You are Vulnerable", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
 
    else if (tpos < 20)
                    {
                        MessageBox.Show("You're Safe", "Important Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(tpos.ToString());
                    }
