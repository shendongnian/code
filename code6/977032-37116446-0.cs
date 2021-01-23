      var rows = activeTab.GetElementsFromGrid();            
                   
                    var cellNameFirstRow= rows[0].CellsContent[2];
                    //name cell from second row.
                    var dropableArea = rows[1].CellsContent[2];
        
                    cellNameFirstRow.DragOn(dropableArea, dropableArea.BoundingRectangle.Location);
    public static bool DragOn(this UITestControl argDragableElement, UITestControl argDropArea, Point argDestinationPoint)
                {
                    try
                    {
                       // argDropArea.DrawHighlight();
                         
                        argDropArea.EnsureClickable(argDestinationPoint);
                        Mouse.StartDragging(argDragableElement, argDragableElement.BoundingRectangle.Location);              
                        Mouse.StopDragging(argDropArea, argDestinationPoint);
                        WriteLine($"Dragging, {argDragableElement.GetSummaryProperties()}");
                        return true;
                    }
                    catch (UITestControlNotFoundException ex)
                    {
                        WriteLine("Could not Drag element ,timeout exceeded ");
                        AssertClick(false, argDragableElement.Name.ToString(), ex.Message);
                    }
                    catch (CustomException ex)
                    {
                        WriteLine("Could not Drag element ,timeout exceeded ");
                        AssertClick(false, argDragableElement.Name.ToString(), ex.Message);
                    }
                    catch (Exception ex)
                    {
                        WriteLine("Could not Drag element ,timeout exceeded ");
                        AssertClick(false, argDragableElement.Name.ToString(), ex.Message);
                    }
                    return false;
                }
