     if(e.OriginalSource is Xceed.Wpf.Toolkit.DateTimePicker)
        {
           if(((Xceed.Wpf.Toolkit.DateTimePicker)e.OriginalSource).IsFocused == true)
           {
              ResetDataTable();
           }
        }
