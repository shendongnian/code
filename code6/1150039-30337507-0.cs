    private Object _selectedComboBoxProperty;
    public Object SelectedComboBoxProperty 
    {
       get { return _selectedComboBoxProperty; }
       set { 
           _selectedComboBoxProperty = value;
 
           // Notify property changed
           OnPropertyChanged("SelectedComboBoxProperty");
           // Update Datagrid_1
           UpdateResults();
    }
    private void UpdateResults()
    {
       // Inspect the current values of your selection properties
       
       // Some business logic to filter the results
       
       // Refresh the collection bound to the Datagrid_1
       
    }
