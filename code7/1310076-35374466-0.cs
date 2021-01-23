    List<MyClass> myList = new List<MyClass>();
    BindingList<MyClass> bList = new BindingList<MyClass>(myList);
    myDataGridView.DataSource = new BindingSource(bList,null);
    
    //Now Lets add a custom column..
    myDataGridView.Columns.Add("Text","Text");
    
    //Now lets edit it's properties
    myDataGridView.Columns["Text"].ReadOnly = false;
    myDataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke;
    
    //Now lets walk through and throw some data in each cell..
    if(myDataGridView.Rows.Count > 1)
    {
         for(int i = 0;i < myDataGridView.Rows.Count;i++)
         {
              myDataGridView.Rows[i].Cells["Text"].Value = "My Super Useful Text";
         }
    }
