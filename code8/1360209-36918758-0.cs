    private void Document_MouseDown(object sender, HtmlElementEventArgs e)
    {
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                HtmlElement element = wb.Document.GetElementFromPoint(PointToClient(MousePosition));
                //I assume I need to check if this element has child elements that contain a TagName "A"
                if (element.TagName == "A")
                {
                    Debug.WriteLine("Get link location, open in new tab.");
                    var urlRaw = element.OuterHtml;
                    string hrefBegin = "href=";
                    var idxHref = urlRaw.IndexOf(hrefBegin) + hrefBegin.Length + 1;
                    var idxEnd = urlRaw.IndexOf("\"", idxHref + 1);
                    var url = urlRaw.Substring(idxHref, idxEnd - idxHref);
                    Debug.WriteLine(url);
                }
                    
                else
                    Debug.WriteLine(element.TagName);
            }
        }
