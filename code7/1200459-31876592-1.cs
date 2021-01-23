    public event MouseEventHandler GridMouseDown 
    { 
      add { dataGrid.MouseDown += value; }
      remove { dataGrid.MouseDown -= value; }
    }
