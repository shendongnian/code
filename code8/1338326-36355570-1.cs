    private void TestListView_ItemClickobject sender, ItemClickEventArgs e)
        {
            RootObject obj = e.ClickedItem as RootObject;
            User.Setting.AddOrUpdateValue("CourseSectionName", obj.name); 
        }
