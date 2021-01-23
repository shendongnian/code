    public class DynamicLayoutGrid : Grid
    {
            
           protected override void OnInitialized(EventArgs e)
           {
                    //Hook up the loaded event (this is used because it fires after the visibility binding has occurred)
                 this.Loaded += new RoutedEventHandler(DynamicLayoutGrid_Loaded);
    
                 base.OnInitialized(e);
            }
    
          
            void DynamicLayoutGrid_Loaded(object sender, RoutedEventArgs e)
            {
                int numberOfColumns = ColumnDefinitions.Count;
                int columnSpan = 0;
                int rowNum = 0;
                int columnNum = 0;
                int visibleCount = 0;
    
                foreach (UIElement child in Children)
                {
                    //We only want to layout visible items in the grid
                    if (child.Visibility != Visibility.Visible)
                    {
                        continue;
                    }
                    else
                    {
                        visibleCount++;
                    }
    
                    //Get the column span of the element if it is not in column 0 as we might need to take this into account
                    columnSpan = Grid.GetColumnSpan(child);
    
                    //set the Grid row of the element
                    Grid.SetRow(child, rowNum);
    
                    //set the grid column of the element (and shift it along if the previous element on this row had a rowspan greater than 0
                    Grid.SetColumn(child, columnNum);
    
                    //If there isn't any columnspan then just move to the next column normally
                    if (columnSpan == 0)
                    {
                        columnSpan = 1;
                    }
    
                    //Move to the next available column
                    columnNum += columnSpan;
    
                    //Move to the next row and start the columns again
                    if (columnNum >= numberOfColumns)
                    {
                        rowNum++;
                        columnNum = 0;
                    }
                }
    
                if (visibleCount == 0)
                {
                    if (this.Parent.GetType() == typeof(GroupBox))
                    {
                        (this.Parent as GroupBox).Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
