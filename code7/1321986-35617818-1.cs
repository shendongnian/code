        public static string[,] mylist { get; set; }// i set the array to static so if the usercontrol is already disposed the array wont get reset to null
        public void pass(ref string[,] name)        // this is where the array designated
        {
            mylist = name;
        }
        private void usercon_AddBook_ControlRemoved(object sender, ControlEventArgs e)
        {
            panel2.Enabled = true;
            for (int i = 0; i <mylist.Length-1; i++)                //  
            {                                                       //
                ListViewItem item = new ListViewItem(mylist[i, 0]); // this will insert the items from array to listview
                item.SubItems.Add(mylist[i, 1]);                    //
                listView1.Items.Add(item);                          //
            }                                                       //
        }
