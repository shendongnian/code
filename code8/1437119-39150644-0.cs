        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNumbers(first.Text, second.Text);
        }
        private void AddNumbers(string text1, string text2)
        {
            string no1 = text1;
            string no2 = text2;
            int ans = (Convert.ToInt32(no1) + Convert.ToInt32(no2));
            MessageBox.Show(" " + ans.ToString());
        }
