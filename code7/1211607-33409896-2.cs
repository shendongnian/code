    private void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      var innerVariableSizedWrapGrid = ControlHelper.FindChild<VariableSizedWrapGrid>(((GridView)AssociatedObject));
      
      if (innerVariableSizedWrapGrid != null)
        innerVariableSizedWrapGrid.MaxHeight = ((GridView)AssociatedObject).ActualHeight;
    }
