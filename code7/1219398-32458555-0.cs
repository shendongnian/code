    if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var position = e.GetPosition(this);
                    if (mousePositionOnButtonPress == new Point())
                    {
                        mousePositionOnButtonPress = new Point(position.X, position.Y);
                    }
                    else
                        if (Math.Abs(mousePositionOnButtonPress.X - position.X) > deltaToStartDrag || Math.Abs(mousePositionOnButtonPress.Y - position.Y) > deltaToStartDrag)
                        {
                            Console.Out.WriteLine("MouseButtonState.Pressed");
    
                            DataGrid dataGrid = sender as DataGrid;
                            prevRowIndex = GetDataGridItemCurrentRowIndex(dataGrid, e.GetPosition);
    
                            if (prevRowIndex < 0) { return; }
    
                            dataGrid.SelectedIndex = prevRowIndex;
                            Employee selectedDV = dataGrid.Items[prevRowIndex] as Employee;
    
                            if (selectedDV == null) { return; }
    
                            DragDropEffects dragDropEffects = DragDropEffects.Move;
                            if (DragDrop.DoDragDrop(dataGrid, selectedDV, dragDropEffects) != DragDropEffects.None)
                            {
                                dataGrid.SelectedItem = selectedDV;
                            }
                        }
                    //
                }
