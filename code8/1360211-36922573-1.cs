     private void Document_MouseDown(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                HtmlElement element = wb.Document.GetElementFromPoint(PointToClient(MousePosition));
                if (element.Children.Count > 0)
                {
                    foreach (HtmlElement child in element.Children)
                    {
                        if (child.TagName == "A")
                            Debug.WriteLine("Get link location, open in new tab.");
                    }
                }
                else
                {
                    //I assume I need to check if this element has child elements that contain a TagName "A"
                    if (element.TagName == "A")
                        Debug.WriteLine("Get link location, open in new tab.");
                    else
                        Debug.WriteLine(element.TagName);
                }
            }
        }
