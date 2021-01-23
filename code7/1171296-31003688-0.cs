        private void UnderlineExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (htmldoc != null)
            {
                bool underline = false;
                htmldoc.Underline();
                IHTMLSelectionObject selec = htmldoc.GetSelection();
                IHTMLElement element = null;
                IHTMLTxtRange txtRange = (IHTMLTxtRange)htmldoc.GetIHTMLDocument2().selection.createRange();
                element = txtRange.parentElement();
                if (element.tagName.Equals("A"))
                {
                    element.style.setAttribute("text-decoration", "none");
                }
                IHTMLElementCollection children = element.all;
                foreach (IHTMLElement child in children)
                {
                    if (child.tagName.Equals("U"))
                    {
                        underline = true;
                    }
                }
                foreach (IHTMLElement child in children)
                {
                    if (child.tagName.Equals("A") && underline == false)
                    {
                        child.style.setAttribute("text-decoration", "none");
                    }
                }
            }
