     var output = new StringBuilder();
            string userSettings = Request.Cookies["UserSettings"].Value;
            output.Append("<div class='search-recent'> <ul>");
            {
                try
                {
                    string[] tokens = userSettings.Split(':');
                    foreach (String searchHist in tokens)
                    {
                        output.Append("<li>" + searchHist + "</li>");
                    }
                }
                catch (Exception ex)
                {
                    output.Append("<li>" + userSettings + "</li>");
                }
                finally
                {
                    output.Append("</div>");
                    recentSearch.Text = output.ToString();
                }
