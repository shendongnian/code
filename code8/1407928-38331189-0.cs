    static void CombineRedundantSpans(IElement parent)
    {
      if (parent != null)
      {               
        if (parent.Children.Length > 1)
        {
          var children = parent.Children.ToArray();
          var previousSibling = children[0];
          for (int i = 1; i < children.Length; i++)
          {
            var current = children[i];
            if (previousSibling is IHtmlSpanElement && current is IHtmlSpanElement)
            {
              if (IsSpanMatch((IHtmlSpanElement)previousSibling, (IHtmlSpanElement)current))
              {
                  previousSibling.TextContent = previousSibling.TextContent + current.TextContent;
                  current.Remove();
               }
               else
                 previousSibling = current;
             }
             else
               previousSibling = current;
           }
         }
         foreach(var child in parent.Children)
         {
           CombineRedundantSpans(child);
         }
       }
    }
    static bool IsSpanMatch(IHtmlSpanElement first, IHtmlSpanElement second)
    {
      if (first.ChildElementCount < 2 && first.Attributes.Length == second.Attributes.Length)
      {
        foreach (var a in first.Attributes)
        {
          if (second.Attributes.Count(t => t.Equals(a)) == 0)
          {
            return false;
          }
        }
        return true;
      }
      return false;
    }
