    private void Find(bool backward)
            {
                string searchString = FindOnPageBox.Text;
                var field = typeof(GWB).GetField("WebBrowser", BindingFlags.Instance | BindingFlags.NonPublic);
                nsIWebBrowser nsIWebBrowser = (nsIWebBrowser)field.GetValue(TheBrowser);
                var browserFind = Xpcom.QueryInterface<nsIWebBrowserFind>(nsIWebBrowser);
                browserFind.SetSearchStringAttribute(searchString);
                browserFind.SetMatchCaseAttribute(YourProgramName.Settings.CaseSensitiveSearch);
                try
                {
                    browserFind.SetWrapFindAttribute(true);
                    browserFind.SetFindBackwardsAttribute(backward);
                    browserFind.FindNext();
                }
                catch { }
            }
