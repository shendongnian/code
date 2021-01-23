      private static object OnCoerceValue(DependencyObject d, object baseValue)
        {  
            if (((DataGrid)d).HasItems)
            {
                DataGridRow row = ((DataGrid)d).ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
                if(row !=null)
                { 
                    if ((bool)baseValue)
                    {
                        FocusManager.SetIsFocusScope(row, true);
                        FocusManager.SetFocusedElement(row, row);
                    }
                    else if (((UIElement)d).IsFocused)
                        Keyboard.ClearFocus();
                }
            }
            return ((bool)baseValue);            
        }
