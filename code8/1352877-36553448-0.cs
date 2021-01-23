    var TheDataToDelete = (from x in MyDC.SomeTable
                           where x.....
                           select x);
    
    if (TheDataToDelete.AnY())
    {
        MyDC.SomeTable.DeleteAllOnSubmit(TheDataToDelete);
        MyDC.SubmitChanges();
    }
