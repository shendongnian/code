    private void gallery1_Click(object sender, RibbonControlEventArgs e)
    {
        //'ribbonGalleryObject' is the object created in Ribbon.Designer.cs
        RibbonDropDownItem item = ribbonGalleryObject.SelectedItem;
        string itemLabel = item.Label;
        string methodName = itemLabel + "_Click";
        System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName);
        methodInfo.Invoke(this, null);
    }
    //click event handler for item 1
    public void myItem1_Click()
    {
        System.Windows.Forms.MessageBox.Show("Item 1 says hello");
    }
    //click event handler for item 2
    public void myItem2_Click()
    {
        System.Windows.Forms.MessageBox.Show("Item 2 says hello");
    }
