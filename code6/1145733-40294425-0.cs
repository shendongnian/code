        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyListBox(listBox1);
            }
        }
        public void CopyListBox(ListBox list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in list.SelectedItems)
            {
                sb.AppendLine(item);
            }
            Clipboard.SetDataObject(sb.ToString());
        }
