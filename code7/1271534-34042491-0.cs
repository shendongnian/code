        private void button1_Click(object sender, EventArgs e)
        {
            string[,] Options = new string[3, 2]{
            {"Invoice", "3"},
            {"Group Invoice", "4"},
            {"Group Invoice BUCKS", "5"} };
       
            for (int i = 0; i < Options.GetLength(0); i++)
            {
                cboOption.Items.Add(new { Text = Options[i, 0], Key = Convert.ToInt16(Options[i, 1]) });
            }
            cboOption.DisplayMember = "Text";
            cboOption.ValueMember = "Key";
        }
