     public static string Parse(this string str, Dictionary<string, Func<string,string>> formatter)
     {
         var formattedStringBuffer = new StringBuilder();
         var formatBuffer = new StringBuilder();
         var tagBuffer = new StringBuilder();
         var state = ParsingState.UnformattedText;
         var activeFormatTag = string.Empty;
         foreach (var c in str)
         {
            switch (state)
             {
                 case ParsingState.UnformattedText:
                     {
                         if (c != '<')
                         {
                             formattedStringBuffer.Append(c);
                         }
                         else
                         {
                             state = ParsingState.OpenTag;
                         }
                         break;
                     }
                 case ParsingState.OpenTag:
                     {
                         if (c != '>')
                         {
                             tagBuffer.Append(c);
                         }
                         else
                         {
                             state = ParsingState.FormattedText;
                             activeFormatTag = tagBuffer.ToString();
                             tagBuffer.Clear();
                         }
                         break;
                     }
                 case ParsingState.FormattedText:
                     {
                         if (c != '<')
                         {
                             formatBuffer.Append(c);
                         }
                         else
                         {
                             state = ParsingState.CloseTag;
                         }
                         break;
                     }
                 case ParsingState.CloseTag:
                     {
                         if (c!='>')
                         {
                             tagBuffer.Append(c);
                         }
                         else
                         {
                             var expectedTag = $"/{activeFormatTag}";
                             var tag = tagBuffer.ToString();
                             if (tag != expectedTag)
                                 throw new FormatException($"Expceted closing tag not found: <{expectedTag}>.");
                             if (formatter.ContainsKey(activeFormatTag))
                             {
                                var formatted = formatter[activeFormatTag](formatBuffer.ToString());
                                 formattedStringBuffer.Append(formatted);
                                 tagBuffer.Clear();
                                 formatBuffer.Clear();
                                 state = ParsingState.UnformattedText;
                             }
                             else
                                 throw new FormatException($"Format tag <{activeFormatTag}> not recognized.");
                         }
                      
                         break;
                     }
             }
         }
         if (state != ParsingState.UnformattedText)
             throw new FormatException($"Bad format in specified string '{str}'");
         return formattedStringBuffer.ToString();
     }
