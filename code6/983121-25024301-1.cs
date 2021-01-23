    public static MvcHtmlString ConvertToArray(this HtmlHelper htmlHelper, object source)
            {
                var src = source as IEnumerable;
    
                if (src == null) return MvcHtmlString.Create(string.Empty);
    
                var sourceAsList = src.Cast<Object>().ToList();
    
                var output = new StringBuilder();
                output.Append("[");
                for (var index = 0; index < sourceAsList.Count; index++)
                {
                    var item = sourceAsList[index];
                    output.Append(item);
                    if (index != (sourceAsList.Count - 1)) output.Append(", ");
                }
                output.Append("]");
    
                return MvcHtmlString.Create(output.ToString());
            }
