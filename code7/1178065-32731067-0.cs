    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Windows.UI.Xaml.Data;
    using System.Net;
    namespace VEJA_Notícias
    {
    public class RssTextTrimmer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            int maxLength = 200;
            int strLength = 0;
            string fixedString = "";
            
            // Remove HTML tags. 
            fixedString = Regex.Replace(value.ToString(), "<[^>]+>", string.Empty);
            // Remove newline characters.
            fixedString = fixedString.Replace("\r", "").Replace("\n", "");
            // Remove encoded HTML characters.
            fixedString = WebUtility.HtmlDecode(fixedString);
            strLength = fixedString.ToString().Length;
            // Some feed management tools include an image tag in the Description field of an RSS feed, 
            // so even if the Description field (and thus, the Summary property) is not populated, it could still contain HTML. 
            // Due to this, after we strip tags from the string, we should return null if there is nothing left in the resulting string. 
            if (strLength == 0)
            {
                return null;
            }
            // Truncate the text if it is too long. 
            else if (strLength >= maxLength)
            {
                fixedString = fixedString.Substring(0, maxLength);
                // Unless we take the next step, the string truncation could occur in the middle of a word.
                // Using LastIndexOf we can find the last space character in the string and truncate there. 
                fixedString = fixedString.Substring(0, fixedString.LastIndexOf(" "));
            }
            fixedString += "...";
            return fixedString;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    }
