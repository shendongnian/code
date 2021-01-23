       var obj = dgvAddPersonTab.SelectedItem;
                var nameOfProperty = "DepartmentName";
                var propertyInfo = obj.GetType().GetProperty(nameOfProperty);
                var value = propertyInfo.GetValue(obj, null);           
                img.Source = new BitmapImage(new Uri(value.ToString())); 
