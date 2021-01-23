        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Appearance = Appearance.Button;
            checkBox2.Appearance = Appearance.Button;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (checkBox2.Checked == true)
                {
                    checkBox2.Checked = false;
                }
            }
            else
            {
                if (checkBox2.Checked != true)
                {
                    checkBox2.Checked = true;
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (checkBox1.Checked == true)
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                if (checkBox1.Checked != true)
                {
                    checkBox1.Checked = true;
                }
            }
        }
