        protected void btnAdd_Click(object sender, EventArgs e) {
          listBox1.Items.Add(textBox3.Text);
          NumericUpDown1.Maximum = 100;
          NumericUpDown1.Minimum = 0;
          textBox5.Text = listBox1.Items.Count.ToString();
          NumericUpDown1.Value += 1;
        }
