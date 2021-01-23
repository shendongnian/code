    private void button1_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.Users.OpenSubKey(".DEFAULT"))
            {
                if (key != null)
                {
                    Object val = key.GetValue("mykey");
                    if (val != null)
                    {
                        MessageBox.Show(val.ToString());
                    }
                    else
                    {
                       MessageBox.Show("Null");
                    }
                }
               
            }
        }
