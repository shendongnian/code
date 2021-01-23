    private void MyList_ItemClick(object sender, ItemClickEventArgs e)
            {
                var item = e.ClickedItem as TestClass;
                if (item != null){
    if(item.IsClickAllowed){
    //Do Stuff here
    }else
    {
    //Do Nothing
    }
            }}
