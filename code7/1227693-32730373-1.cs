    private void gridViewBatches_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) 
    {
    	GridView view = sender as GridView;
    
    	if (view.FocusedColumn.FieldName == "Batch No") //Editable true
    	{
    		e.Cancel = false;
    	} else //Other column editble false
    	{
    		e.Cancel = true;
    	}
    }
