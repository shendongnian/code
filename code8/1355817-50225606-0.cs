    public static IEnumerable<T> ToArray<T>(this ExcelWorksheet worksheet, List<PropertyNameResolver> resolvers) where T : new()
    {
      // List of all the column names
      var header = worksheet.Cells.GroupBy(cell => cell.Start.Row).First();
      
      // Get the properties from the type your are populating
      var properties = typeof(T).GetProperties().ToList();
      var start = worksheet.Dimension.Start;
      var end = worksheet.Dimension.End;
      // Resulting list
      var list = new List<T>();
      // Iterate the rows starting at row 2 (ie start.Row + 1)
      for (int row = start.Row + 1; row <= end.Row; row++)
      {
        var instance = new T();
        for (int col = start.Column; col <= end.Column; col++)
        {
          object value = worksheet.Cells[row, col].Text;
          
          // Get the column name zero based (ie col -1)
          var column = (string)header.Skip(col - 1).First().Value;
          // Gets the corresponding property to set
          var property = properties.Property(resolvers, column);
          
          try
          {
            var propertyName = property.PropertyType.IsGenericType
              ? property.PropertyType.GetGenericArguments().First().FullName
              : property.PropertyType.FullName;
            // Implement setter code as needed. 
            switch (propertyName)
            {
              case "System.String":
                property.SetValue(instance, Convert.ToString(value));
                break;
              case "System.Int32":
                property.SetValue(instance, Convert.ToInt32(value));
                break;
              case "System.DateTime":
                if (DateTime.TryParse((string) value, out var date))
                {
                  property.SetValue(instance, date);
                }
                property.SetValue(instance, FromExcelSerialDate(Convert.ToInt32(value)));
                break;
              case "System.Boolean":
                property.SetValue(instance, (int)value == 1);
                break;
            }
          }
          catch (Exception e)
          {
            // instance property is empty because there was a problem.
          }
        } 
        list.Add(instance);
      }
      return list;
    }
    // Utility function taken from the above post's inline function.
    public static DateTime FromExcelSerialDate(int excelDate)
    {
      if (excelDate < 1)
        throw new ArgumentException("Excel dates cannot be smaller than 0.");
      var dateOfReference = new DateTime(1900, 1, 1);
      if (excelDate > 60d)
        excelDate = excelDate - 2;
      else
        excelDate = excelDate - 1;
      return dateOfReference.AddDays(excelDate);
    }
    
