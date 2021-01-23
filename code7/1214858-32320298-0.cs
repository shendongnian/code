     static void Main(string[] args)
     {
         var text = "@Time:08:30PM,@Date:08/30/2015,@Duration:4,";
     
         var Time = GetValueForItem("Time", text);
         var Date = GetValueForItem("Date", text);
         var Duration = GetValueForItem("Duration", text);
     }      
     static string GetValueForItem(string item, string text)
     {
         item = $"@{item}:"; //if pre C#6 use string.Format("@{0}:, item)
         var index = text.IndexOf(item);
         var chars = text.Substring(index + item.Length).TakeWhile(c => c != ',');
         return string.Concat(chars);
     }
