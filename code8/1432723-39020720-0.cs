    // Event declaration. You can, after that, bind it elsewhere.
    public event EventHandler<SelectionEventArgs> SelectedRowsChanged;
    
    // This is the local implementation wich will fire the event.
    // Here you invoke the event with the selected rows id's.
    public void OnSelectedRowsChanged() { if (SelectedRowsChanged != null) CustomSelection(this, new SelectionEventArgs(this.SelectedRows)); }
    
    // This is the custom implementation of the EventArgs to include the
    // event-related data (row id)
    public class SelectionEventArgs : EventArgs
    {
       public int[] SelectedRows{ get; private set; }
       public SelectionEventArgs(int[] selectedRows) { SelectedRows = selectedRows; }
    }
    // ... then, somewhere else on your code
    this.myControl.SelectedRowsChanged += myControl_SelectedRowsChanged;
    public void myControl_SelectedRowsChanged(object sender, SelectionEventArgs e)
    {
       if (e.SelectedRows.Length > 0) { /* do something */ }
    }
