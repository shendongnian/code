    private void Document_MouseDown(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                HtmlElement element = wb.Document.GetElementFromPoint(PointToClient(MousePosition));
                //I assume I need to check if this element has child elements that contain a TagName "A"
                if (element.TagName == "A" && !string.IsNullOrEmpty(element.GetAttribute("href")))//it means we have deal with href
                {
                    Debug.WriteLine("Get link location, open in new tab.");
                    var url = element.GetAttribute("href");
                    Debug.WriteLine(url);
                }
                    
                else
                    Debug.WriteLine(element.TagName);
            }
        }
