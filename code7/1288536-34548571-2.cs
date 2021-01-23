    // simplified
    class Container {
      public double Nue {get; set;}
      public double Mue {get; set;}
      public double MPc {get; set;}
    }
 
----------
    ObservableCollection<Container> containers = ...
    dataGrid.ItemSource = containers;
