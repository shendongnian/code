    public Form2(List<string> passedValues, int vanillaCount)
            {
                InitializeComponent();
    
                // This line let you show more Columns
                listView1.View = View.Details;
    
                // Define your needed Columns 
                listView1.Columns.Add("Item-Name", -2); //(the width with -2 means, that the column will be autosized)
                listView1.Columns.Add("Quantity");
    
                foreach (var item in passedValues)
                {
                    // Create a new ListViewItem "Vanilla", add your needed Subitems like Quantity, Price, ...
                    var newItem = new ListViewItem(item);
                    newItem.SubItems.Add(vanillaCount.ToString());
    
                    // add the new Item to your ListView 
                    listView1.Items.Add(newItem);
                }
            }
