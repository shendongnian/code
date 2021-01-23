    private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            String i = cmbParent.Text;
            cmbChild.Items.Clear(); //clear the child combo items.
            foreach (var item in listChild)
            {
                if (item.Item1.Equals(i))
                {
                    cmbChild.Items.Add(item.Item2);
                }
            }
        }
