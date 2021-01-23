       var obj = dgvAddPersonTab.SelectedItem;
                var nameOfProperty = "FifthPicAddress";
                var propertyInfo = obj.GetType().GetProperty(nameOfProperty);
                var value = propertyInfo.GetValue(obj, null);           
                img.Source = new BitmapImage(new Uri(value.ToString())); 
           
