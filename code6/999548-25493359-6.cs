    private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listBox1.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    listBox1.SelectedIndex = item;
                    listBoxSnap.SelectedIndex = listBox1.SelectedIndex;
                    cm.Show(listBox1, e.Location);
                }
            }
        }
