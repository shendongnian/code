    class DataGridTextColumnEx : DataGridTextColumn
            {
                protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
                {
                    var textBlock = base.GenerateElement(cell, dataItem) as TextBlock;
    
                    //Probably use dataItem to set color
                    textBlock.Background = Brushes.Red;
    
                    return textBlock;
                }
    
                protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
                {
                    var textBox = base.GenerateEditingElement(cell, dataItem) as TextBox;
    
                    //Probably use dataItem to set color
                    textBox.Background = Brushes.Blue;
    
                    return textBox;
                }
            }
