          <Grid GiveFeedback="Members_GiveFeedback">
                    <Popup x:Name="dragPopup" Placement="MousePoint">
                        <Border BorderThickness="2" Background="White" DataContext="{Binding}">
                            <StackPanel Orientation="Horizontal" Margin="4,3,8,3">
                                <TextBlock Text="Test" FontWeight="Bold" VerticalAlignment="Center" Margin="8,0,0,0" />
                            </StackPanel>
                        </Border>
                    </Popup>
                    <StackPanel Orientation="Horizontal">
                        <ListBox x:Name="sourcList" Height="50"
                        PreviewMouseLeftButtonDown="ListBox_PreviewMouseLeftButtonDown"
                        PreviewMouseMove="sourcList_PreviewMouseMove"
                        AllowDrop="True" >
                            <ListBoxItem > source Item #1</ListBoxItem>
                    </ListBox>
            
                    <ListBox x:Name="droplist" Height="50" AllowDrop="True" Drop="droplist_Drop" >
                            <ListBoxItem >dest Item #2</ListBoxItem>
                        </ListBox>
                    </StackPanel>
                </Grid>
    
        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
                {
                    var mousePoint = Mouse.GetPosition(this);
                    startPoint=mousePoint;
        
                    var point = GetMousePositionWindowsForms();
                    var formsmousePoint = new Point(point.X, point.Y);
                    var pointfromscreen = dragPopup.PointFromScreen(formsmousePoint);
                    dragPopup.HorizontalOffset = pointfromscreen.X - 100;
                    dragPopup.VerticalOffset = pointfromscreen.Y - 100;
                    dragPopup.IsOpen = true;
                }
                private void sourcList_PreviewMouseMove(object sender, MouseEventArgs e)
            {
              ...                 
            }
      private void droplist_Drop(object sender, DragEventArgs e)
            {
    
               ...
                
            }
        private void Members_GiveFeedback(object sender, GiveFeedbackEventArgs e)
            {
                if (dragPopup.IsOpen)
                {
                    var point=GetMousePositionWindowsForms();
                    var mousePoint = new Point(point.X, point.Y);
                    var pointfromscreen=dragPopup.PointFromScreen(mousePoint);
                    dragPopup.HorizontalOffset = pointfromscreen.X-100;
                    dragPopup.VerticalOffset = pointfromscreen.Y-100;
                }
            }
        
            public static Point GetMousePositionWindowsForms()
            {
                System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
                return new Point(point.X, point.Y);
            }
