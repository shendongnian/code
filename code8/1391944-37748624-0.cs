    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    public static class CheckedListBoxExtensions
    {
        public static string CheckedItemsJoined(this CheckedListBox sender)
        {
            var Result = from singleItem in sender.Items.OfType<string>().Where(
                             (item, index) =>
                             {
                                 return sender.GetItemChecked(index);
                             }
                         )
                         select singleItem;
    
            return string.Join(",", Result.ToList<string>());
        }
    }
