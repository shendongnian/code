    class CommentsConverter : IValueConverter
    {
      /// <summary>
      /// An example for a converter that will return 
      /// "Warning: Wild Unicorns found on premise." 
      /// if the word "unicorn" exists in the string.
      /// </summary>
      public object Convert(object value,Type targetType,object parameter,CultureInfo culture)
      {
        var input_string = value as string;
        if (input_string.IsNullOrEmpty()) 
          return "The cake is a lie.";
        if (input_string.Contains("unicorn"))
          return "Warning: Wild Unicorns found on premise.";
        
        return "This following text is Unicorn free: [" + input_string + "]";
      }
    
      /// <summary>
      /// It it makes sense to convert back, IMPLEMENT the following method as well !!!!
      /// </summary>
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }  
