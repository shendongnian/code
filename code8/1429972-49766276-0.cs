    public class StretchyWrapPanel : Panel
    	{
            // Default vertical offset
    		const int ElementVerticalOffset = 5;
    
    		protected override Size MeasureOverride(Size constraint)
    		{
    			Size currentLineSize = new Size();
    			Size panelSize = new Size();
    
    			foreach (UIElement element in InternalChildren)
    			{
    				// Compute element size
    				element.Measure(constraint);
    				Size desiredSize = element.DesiredSize;
    
    				// Go to new line
    				if (currentLineSize.Width + desiredSize.Width > constraint.Width)
    				{
    					panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
    					panelSize.Height += currentLineSize.Height + ElementVerticalOffset;
    					currentLineSize = desiredSize;
    
    					// If width of element is more than our constrait -> go to new line
    					if (desiredSize.Width > constraint.Width)
    					{
    						panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
    						panelSize.Height += currentLineSize.Height + ElementVerticalOffset;
    						currentLineSize = new Size();
    					}
    				}
    				// If element can be placed in line
    				else
    				{
    					currentLineSize.Width += desiredSize.Width;
    					currentLineSize.Height = Math.Max(desiredSize.Height, currentLineSize.Height);
    				}
    			}
    			panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
    			panelSize.Height += currentLineSize.Height;
    			return panelSize;
    		}
    
    		protected override Size ArrangeOverride(Size finalSize)
    		{
    			var currentLineSize = new Size();
    			Size panelSize = new Size();
    
    			double offsetLeft = 0;
    			double offsetTop = 0;
    
    			foreach (UIElement element in InternalChildren)
    			{
    				Size desiredSize = element.DesiredSize;
    
    				var elementCountInLine = (int)(finalSize.Width / desiredSize.Width);
    				int elementHorizontalOffset = (int)((finalSize.Width - elementCountInLine * desiredSize.Width) / (elementCountInLine));
    
    				if (currentLineSize.Width + desiredSize.Width + elementHorizontalOffset > finalSize.Width)
    				{
    					panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
    					panelSize.Height += currentLineSize.Height;
    					currentLineSize = desiredSize;
    
    					if (desiredSize.Width > finalSize.Width)
    					{
    						panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
    						panelSize.Height += currentLineSize.Height;
    						currentLineSize = new Size();
    					}
    					offsetLeft = 0;
    					offsetTop += desiredSize.Height + ElementVerticalOffset;
    				}
    				else
    				{
    					currentLineSize.Width += desiredSize.Width + elementHorizontalOffset;
    					currentLineSize.Height = Math.Max(desiredSize.Height, currentLineSize.Height);
    				}
    				element.Arrange(new Rect(new Point(offsetLeft, offsetTop), element.DesiredSize));
    				offsetLeft += desiredSize.Width + elementHorizontalOffset;
    			}
    
    			return finalSize;
    		}
    	}
