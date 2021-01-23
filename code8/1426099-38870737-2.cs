    private void myDropdownGallery_Click(object sender, RibbonControlEventArgs e)
    {
        //'ribbonGalleryObject' is the object created in Ribbon.Designer.cs
        RibbonDropDownItem item = ribbonGalleryObject.SelectedItem;
        string itemLabel = item.Label;
        if (itemLabel == "myItem1") {
            System.Windows.Forms.MessageBox.Show("Item 1 says hello");
        }
        else if (itemLabel == "myItem1"){
            System.Windows.Forms.MessageBox.Show("Item 2 says hello");
        }
    }
