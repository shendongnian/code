     if (checkedListBox1.CheckedItems.Count == 0)
     {
        Empty.SetError(checkedListBox1, "Please select at Least One");
     }
     for (int i = 0; i < checkedListBox1.Items.Count; i++)
       if (checkedListBox1.GetItemChecked(i))
       {
         MessageBox.Show(checkedListBox1.Items[i].ToString());
       }
