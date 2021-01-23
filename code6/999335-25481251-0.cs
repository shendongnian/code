        private void button1_Click(object sender, EventArgs e)
        {
            List<Control> checkedRB = new List<Control>();
            foreach (RadioButton rb in groupBox1.Controls)
            {
                if (rb.Checked)
                    checkedRB.Add(rb);
            }
            foreach (RadioButton rb in groupBox2.Controls)
            {
                if (rb.Checked)
                    checkedRB.Add(rb);
            }
            foreach (Control ctrl in checkedRB)
                    Console.WriteLine(ctrl.Name);
        }
