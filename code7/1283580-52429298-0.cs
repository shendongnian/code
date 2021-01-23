    using System.Printing;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    private void Imprimir(object view)
    {
    	var fe = new Grid();
    	fe = (Grid)view;
    	var feSize = new Size(((Grid)view).Width, ((Grid)view).Height); //for resize back to original size
    
    	try
    	{
    		var dialog = new PrintDialog();
    		dialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
    		dialog.PrintTicket = dialog.PrintQueue.DefaultPrintTicket;
    		dialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
    
    		var capabilities = dialog.PrintQueue.GetPrintCapabilities(dialog.PrintTicket);
    
    		//Here my view is resized  
    		fe.Height = capabilities.PageImageableArea.ExtentHeight;
    		fe.Width = capabilities.PageImageableArea.ExtentWidth;
    		fe.UpdateLayout();
    
    		fe.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    		Size size = new Size(fe.DesiredSize.Width, fe.DesiredSize.Height);
    		fe.Measure(size);
    		size = new Size(capabilities.PageImageableArea.ExtentWidth,
    						 capabilities.PageImageableArea.ExtentHeight);
    		fe.Measure(size);
    		fe.Arrange(new Rect(size));
    
    		var ret = dialog.ShowDialog() ?? false;
    		if (ret)
    			dialog.PrintVisual(fe, "Grid Printing");
    	}
    	finally
    	{
    		//Here I resize my view to the original size
    		fe.Height = feSize.Height;
    		fe.Width = feSize.Width;
    		fe.UpdateLayout();
    
    		fe.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    		Size size = new Size(fe.Width, fe.Height);
    		fe.Measure(size);
    		fe.Arrange(new Rect(size));
    	}
    
    }
