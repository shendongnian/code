        private void UpdateTheListboxMaintainExistingOrSelectLastAdded(Dictionary<string, string> incomingDictionary, ListBox listboxToModify)
        {
            var preSelectedItem = listboxToModify.SelectedItem;//store the current selection
            listboxToModify.Items.Clear();//clear all the items in the list
            foreach (KeyValuePair<string, string> item in incomingDictionary)
            {
                listboxToModify.Items.Add(item.Key);
            }
            //this method should probably be optimized because if your listBox already contains a large number of items
            //it may be quicker to only add the missing items, instead of reverting back to an empty list, and adding all the items to it again.
            //Though I'll leave this up to you to implement. We'll be here to answer questions if you have a hard time doing it.
            
            if (preSelectedItem != null)
            {
                //Maintain the selected item if there was one
                listboxToModify.SelectedItem = preSelectedItem;
            }
            else
            {
                //select the last item in the listbox if nothing was pre-selected
                listboxToModify.SelectedItem = listboxToModify.Items[listboxToModify.Items.Count - 1];
            }
        }
