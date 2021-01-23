    ViewHelper.SetBulkVisibility(Visibility.Collapsed, new List<dynamic> {SP1, SP2, SP3});
    
     public static class ViewHelper
        {
            public static void SetBulkVisibility(Visibility value, IEnumerable<dynamic> objects)
            {
                foreach (var o in objects)
                {
                    o.Visibility = value;
                }
            }
        }
