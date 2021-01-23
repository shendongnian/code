        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            List<TextBox> box = new List<TextBox>();
            box = pMainScreen.Controls.OfType<TextBox>().Where(c => c.Name.Contains("")).ToList();
            foreach(TextBox b in box)
            {
                if (b.SelectionLength > 0)
                    label7.Text = b.Text;
            }
        }
