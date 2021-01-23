    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {mouseDown = true;
                mouseDownPos = e.GetPosition(canvasWaSNA);
                theGrid.CaptureMouse();
                sBox.StrokeThickness = 1.5 / zoomfactor;
                // Initial placement of the drag selection box.         
                Canvas.SetLeft(sBox, mouseDownPos.X);
                Canvas.SetTop(sBox, mouseDownPos.Y);
                sBox.Width = 0;
                sBox.Height = 0;
                // Make the drag selection box visible.
                sBox.Visibility = Visibility.Visible;
            }
