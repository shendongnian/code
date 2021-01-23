      class DataGridTextColumnEx : DataGridTextColumn
        {      
            protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
            {
                var element = base.GenerateElement(cell, dataItem);
                cell.Tag = dataItem;
    
                element.IsVisibleChanged += Element_IsVisibleChanged;
    
                return element;
            }
            
            private void Element_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                var textBlock = sender as TextBlock;
                var cell = textBlock.Parent as DataGridCell;
                var data = cell.Tag;
                if (textBlock.Visibility == Visibility.Visible)
                {
                    //Use data to do validation...
                    textBlock.Background = Brushes.LightPink;
                }
            }
        }
