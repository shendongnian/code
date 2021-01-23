    private void button_ekle_Click(object sender, EventArgs e)
    {   
        for (int k = clb_input.Items.Count - 1; k >= 0; k--)
        {
            if (clb_input.GetItemChecked(k) == true)
            {   
                clb_output.Items.Add(clb_input.Items[k]);
                // Remove from the Items collection, not from the CheckedItems collection
                clb_input.Items.RemoveAt(k);
            }
            else { }
        }
    }
