    public static IHtmlString CheckBoxesForEnumModel<TModel>(this HtmlHelper<TModel> htmlHelper) where TModel : struct, IConvertible
    {
       if (!typeof(TModel).IsEnum)
       {
          throw new ArgumentException("this helper can only be used with enums");
       }
       //Here some code to get all the values and the names for this Enum        
       //But HOW?? 
       return new HtmlString("ideally this is some html checkboxes with each enum description");
    }
