        private void btnSort_Click(object sender, EventArgs e)
        {
            listView1.ListViewItemSorter = new ListViewItemComparer(2); // Column number 2
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sort();            
        }
