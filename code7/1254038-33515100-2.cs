     .Select(y => new BrochureTemplateProperties
                {
                    IsChecked = y.IsChecked,
                    Name = y.Property_Title,
                    PropertyValue = y.Property_Value
                }).FirstOrDefault(); //here
