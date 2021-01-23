        List<string> orderedSelection = new List<string>();
        bool flag = true;
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                var list1 = listBox3.SelectedItems.Cast<string>().ToList();
                if (listBox3.SelectedItems.Count > orderedSelection.Count)
                {
                    orderedSelection.Add(list1.Except(orderedSelection).First());
                }
                else if (listBox3.SelectedItems.Count < orderedSelection.Count)
                {
                    orderedSelection.Remove(orderedSelection.Except(list1).First());
                }
                var list2 = listBox3.Items.Cast<string>().Except(list1).ToList();
                listBox3.Items.Clear();
                for (int i = 0; i < list1.Count; i++)
                {
                    listBox3.Items.Add(list1[i]);
                    listBox3.SelectedIndex = i;
                }
                foreach (string s in list2)
                {
                    listBox3.Items.Add(s);
                }
                flag = true;
            }
        }
