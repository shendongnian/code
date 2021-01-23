    class FindCategoryProperty: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                var categoryList = (IList<CategoryClass>) value;
                var categoryStringTuple = (Tuple<categoryID, string>) parameter;
                var categoryID = categoryStringTuple.Item1;
                var child = categoryList.FirstOrDefault(c => c.CategoryID == categoryID);
                if (child != null)
                {
                    switch (categoryStringTuple.Item2)
                        {
                            case "Property1":
                                return child.getProperty1();
                            case "Property2":
                                return child.getProperty2();
                            //etc
                            default:
                                return "";
                        }
                }
            }
            return "";
        }
    
        //Left the ConvertBack unimplemented
    }
