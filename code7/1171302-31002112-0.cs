            PdfReader pdfReader = new PdfReader(GlobalVars.PdfFile);
            IList<Dictionary<string, object>> bookmarks = SimpleBookmark.GetBookmark(pdfReader);
            string BookmarkID = "";
            for (int j = 0; j < bookmarks.Count; j++)
            {
                //MessageBox.Show(bookmarks[i].Values.ToArray().GetValue(0).ToString());
                string s = bookmarks[j].Values.ToArray().GetValue(0).ToString();
                if (bookmarks[j].Values.ToArray().GetValue(0).ToString() == "##PODPIS##")
                {
                    BookmarkID = bookmarks[j].Values.ToArray().GetValue(1).ToString();
                }
                
            }
            var map = SimpleNamedDestination.GetNamedDestination(pdfReader, true);
            foreach (KeyValuePair<string, string> entry in map)
            {
                if (entry.Key.ToString() == BookmarkID)
                {
                    string[] LocationArray = entry.Value.Split(null);
                    GlobalVars.SignatuePageNumber = Convert.ToInt32(LocationArray[0]);
                    GlobalVars.SignatureX = float.Parse(LocationArray[2], CultureInfo.InvariantCulture.NumberFormat);
                    GlobalVars.SignatureY = float.Parse(LocationArray[3], CultureInfo.InvariantCulture.NumberFormat);
                }
            }
