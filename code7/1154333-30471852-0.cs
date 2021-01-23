        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedIndices.Count; i++)
                listView1.Items[listView1.SelectedIndices[i]].BackColor = pictureBox1.BackColor;
        }
