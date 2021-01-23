    private void myDropdownGallery_Click(object sender, RibbonControlEventArgs e)
        {
        RibbonDropDownItem item = chartDropDown.SelectedItem;
        string itemLabel = item.Label;
        if (itemLabel == "myItem1") {
            System.Windows.Forms.MessageBox.Show("Item 1 says hello");
        }
        else if (itemLabel == "myItem1"){
            System.Windows.Forms.MessageBox.Show("Item 2 says hello");
        }
    }
