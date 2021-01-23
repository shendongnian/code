        private void rollBtn_Click(object sender, EventArgs e)
        {
            int t1 = 0;
            int.TryParse(turnsTxt.Text, out t1)
            int t2 = t1 + 1;
            turnsTxt.Text = t2.ToString(); 
            ...
            //rest of your code
        }
