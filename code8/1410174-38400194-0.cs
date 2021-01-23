        private void BaseView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var window = sender as Window;
            
            if (ChildUserControl.HasItems)
            {
                var chlidControl = ChildUserControl.Items[0] as UserControl;
                var context = (BaseWindowViewModel)window.DataContext;
                // Ignore the first 3 resize events - these occur on view generation
                if (!context.InitialResizeComplete)
                    if (context.ResizeOperations < 3)
                    {
                        context.ResizeOperations++;
                        return;
                    }
                context.InitialResizeComplete = true;
                // Subtract all fixed size elements from window dimensions
                chlidControl.Width = window.ActualWidth - (OuterBorder.BorderThickness.Left + OuterBorder.BorderThickness.Right + OuterBorder.Margin.Right + OuterBorder.Margin.Left);
                chlidControl.Height = window.ActualHeight - (OuterBorder.BorderThickness.Top + OuterBorder.BorderThickness.Bottom + OuterBorder.Margin.Top + OuterBorder.Margin.Bottom + TaskBarGrid.Height);
            }
        }
