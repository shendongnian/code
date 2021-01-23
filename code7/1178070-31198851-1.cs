    static string CompletedItems = "";
    [System.Web.Services.WebMethod]
            public static string readAsync()
            {
                return "" + CompletedItems + "........Complete\n";
            }
    
            [System.Web.Services.WebMethod]
            public static void startAsync()
            {
                asyncTask();
            }
    
            private static void asyncTask()
            {
                foreach (var listBoxItem in serverlist.Items)
                {
                    string send = listBoxItem.ToString();
                    DELETEPROFILE(send);
                    //consolebox.Text += ("" + send + "........Complete" + Environment.NewLine);
                    CompletedItems += send + ",";
                }
            } 
