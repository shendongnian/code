    private void myCarsGridView_ShownEditor(object sender, EventArgs e)
    {
    	try
    	{
    		ColumnView view = (ColumnView)sender;
    		if (view.FocusedColumn.FieldName == "CarType.Id" && view.ActiveEditor is LookUpEdit)
    		{
    			LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
    			int carTypeId = (int)view.GetFocusedRowCellValue("CarType.Id");
    			IList<Car> filteredCars = _controller.GetCarsByType(carTypeId);
    			edit.Properties.DataSource = filteredCars;
    		}
    	}
    	catch (System.Exception ex)
    	{
    		//Log
    	}
    
    }
