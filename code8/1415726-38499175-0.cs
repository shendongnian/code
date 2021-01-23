     private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sitem = listBox1.SelectedItem.ToString();
            int index = listBox2.FindString(sitem);
            listBox2.SetSelected(index, true);
        }
