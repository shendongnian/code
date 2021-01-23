        private void radButton1_Click(object sender, EventArgs e)
        {
            string perp = radTextBox1.Text;
            int i = 0;
            DataRow arp = ale.Rows[i];
            while (i <= ale.Rows.Count)
            {
                if (ale.Rows[i].Field<>("FullName") = perp)
                {
                    arp = ale.Rows[i];
                    ale.Rows.Remove(arp);
                }
            }
            i = ale.Rows.Count;
            radLabel1.Text = i.ToString();
        }
