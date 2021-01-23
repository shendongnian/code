    public partial class MainWindow ...
    {
       public DataGrid grid;
    
       public MainWindow()
       {
          ...
       }
    
       public void DataGrid_Loaded(...)
       {
         ...
         grid = sender as DataGrid;
         ...
       }
    }
