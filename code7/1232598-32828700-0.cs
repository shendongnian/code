        private List<TextBox> TextBoxes = new List<TextBox>();
        private void btnMaterialAdd_Click(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            int i = TextBoxes.Count + 1;
            tb.Location = new Point(1, i * 30);
            tb.Width = 30;
            tb.Name = "ID" + i;
            tb.Text = i.ToString();
            TextBoxes.Add(tb);
            panel1.Controls.Add(tb);
        }
