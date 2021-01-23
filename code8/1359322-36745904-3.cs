        private void btnList_Click(object sender, EventArgs e)
        {
            List<ExampleObject> templist = new List<ExampleObject>();
            var collection = listView1.Items;
            foreach (var item in collection)
            {
                ListViewItem obj = (ListViewItem)item;
                var subitems = obj.SubItems;
                List<string> stringlist = new List<string>();
                
                foreach (ListViewSubItem subitem in subitems)
                {
                    stringlist.Add(subitem.Text);
                }
                ExampleObject tempobject = new ExampleObject()
                {
                    DueDate = stringlist[0],
                    Module = stringlist[1],
                    Title = stringlist[2]
                };
                templist.Add(tempobject);
            }
        }
