    List<object> checkedItems = new List<object>(); //List to save checked items
    object[] checkListBoxItems = new object[]       //CheckedListBox items
    {
    "item1","item2","item3","item4","item5"
    }
    //Method called when item is checked in checkedListBox
    private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                //If item is checked and not already on list, we add it to de list
                //With this filter we prevent adding the same item multiple times on rebind
                if (!checkedItems.Contains(checkedListBox1.Items[e.Index]))
                {
                    checkedItems.Add(checkedListBox1.Items[e.Index]);
                }
            } 
            else
            {
                //If not checked, we remove it from list
                checkedItems.Remove(checkedListBox1.Items[e.Index]);
            }
        }
    
    private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Start update of checkedlistbox and clear items to refill
            checkedListBox1.BeginUpdate();
            checkedListBox1.Items.Clear();
            //If there is any text on the filter field
            if (!string.IsNullOrEmpty(textBox1.Text))
            {   
                //We check every item on our original item list (object array)
                foreach(object item in checkListBoxItems)
                {
                    //Check if string in textfield matches item (case sensitive) 
                    //and adds it to checkedListBox. At this point we should see the item
                    if (item.ToString().Contains(textBox1.Text))
                    {
                        checkedListBox1.Items.Add(item);
                    }
                }
            }
            else
            {
                //If filter string is empty, we add the whole array of items to the list
                checkedListBox1.Items.AddRange(checkListBoxItems);
            }
            //Now checkedListBox is filled with the filtered(or not) items, its time
            //to check if they where checked previously and check them in the new list
            if(checkedClients.Count > 0)
            {
                foreach (object item in checkedListBoxItems)
                {
                    if (checkedItems.Contains(item))
                    {
                        //If item is shown in the list atm (otherwise it will crash)
                        if(checkedListBox1.Items.Contains(item)
                        {
                             checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(item), true);
                        }
                        
                    }
                }
            }
            checkedListBox1.EndUpdate();
        }
