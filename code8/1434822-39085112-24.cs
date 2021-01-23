        Dictionary<string, string> fileDictionary = new Dictionary<string, string>();
        private void blaze_125_listbox4_Drop_Slimmer(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] droppedFilePaths =
                    e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string droppedFilePath in droppedFilePaths)
                {
                    //listbox4.Items.Add(System.IO.Path.GetFileName(droppedFilePath));//don't need this anymore
                    //Check if the file is already in the dictionary.
                    //Check by looking up the key, and by looking up the value too.
                    if (fileDictionary.ContainsKey(System.IO.Path.GetFileName(droppedFilePath)) || fileDictionary.ContainsValue(droppedFilePath))
                    {
                        //no need to add this file, it's already in the dictionary
                        //if you try to add a file with a KEY identical to a KEY that already exists in the dictionary,
                        //it will throw an exception
                        //A dictionary can contain the same value multiple times, but it can not contain the same key more than once.
                    }
                    else
                    {
                        //the file is not listed in the dictionary, so lets add it
                        fileDictionary.Add(System.IO.Path.GetFileName(droppedFilePath), droppedFilePath);
                    }
                }
            }
            //Now lets call the method in charge of updating the listbox 
            UpdateTheListbox(fileDictionary, listbox4);
        }
        private void UpdateTheListbox(Dictionary<string, string> incomingDictionary, ListBox listboxToModify)
        {
            listboxToModify.Items.Clear();//clear all the items in the list
            foreach (KeyValuePair<string, string> item in incomingDictionary)
            {
                listboxToModify.Items.Add(item.Key);
            }
            //this method should probably be optimized because if your listBox already contains a large number of items
            //it may be quicker to only add the missing items, instead of reverting back to an empty list, and adding all the items to it again.
            //Though I'll leave this up to you to implement. We'll be here to answer questions if you have a hard time doing it.
        }
