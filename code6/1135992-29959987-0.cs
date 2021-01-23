      bool FindFirst(HtmlElement elem, string text)
      {
            if (elem.Document != null)
            {
                IHTMLDocument2 doc =
                    elem.Document.DomDocument as IHTMLDocument2;
                IHTMLSelectionObject sel = doc.selection as IHTMLSelectionObject;
                sel.empty();
                
                IHTMLTxtRange rng = sel.createRange() as IHTMLTxtRange;
               // MoveToElement causes the search begins from the element
                rng.moveToElementText(elem.DomElement as IHTMLElement);
                if (rng.findText(text, 1000000000, 0))
                {
                    rng.select();
                    rng.scrollIntoView(true);
                    return true;
                }               
            }
            return false;
      }
       public bool FindNext(HtmlElement elem, string text)
        {
            if (elem.Document != null)
            {
                IHTMLDocument2 doc =
                    elem.Document.DomDocument as IHTMLDocument2;
                IHTMLSelectionObject sel = doc.selection as IHTMLSelectionObject;              
                IHTMLTxtRange rng = sel.createRange() as IHTMLTxtRange;
                rng.collapse(false);
                if (rng.findText(text, 1000000000, 0))
                {
                    rng.select();
                    rng.scrollIntoView(true);
                    return true;
                }
            }
            return false;
        }
