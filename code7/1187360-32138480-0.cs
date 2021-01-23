    List<OpenXmlElement> elems =new List<OpenXmlElement>(doc.MainDocumentPart.Document.Body.Descendants());
    var crs=doc.MainDocumentPart.RootElement.Descendants<CommentRangeStart>();
    var cre=doc.MainDocumentPart.RootElement.Descendants<CommentRangeEnd>();
    var dic_cr=new Dictionary<CommentRangeStart, CommentRangeEnd>();
    for (int i = 0; i < crs.Count(); i++)
    {
        dic_cr.Add(crs.ElementAt(i), cre.ElementAt(i));
    }
    for (int i = 0; i < elems.Count; i++)
        if (elems.ElementAt(i).LocalName.Equals("t"))
           if (isInsideAnyComment(dic_cr, elems.ElementAt(i)))
               for (int j = 0; j < dic_cr.Count; j++)
                   if (isInsideAComment(dic_cr.ElementAt(j), elems.ElementAt(i)))
                        String text = ((Text)elems.ElementAt(i)).InnerText;
    
    public bool isInsideAnyComment(IDictionary<CommentRangeStart, CommentRangeEnd> dic_cr, OpenXmlElement item)
        {
            foreach (var i in dic_cr)
                if (item.IsAfter(i.Key) && item.IsBefore(i.Value))
                    return true;
            return false;
        }
    
    public bool isInsideAComment(KeyValuePair<CommentRangeStart, CommentRangeEnd> dic_cr_elem, OpenXmlElement item)
        {
            if (item.IsAfter(dic_cr_elem.Key) && item.IsBefore(dic_cr_elem.Value))
                return true;
            return false;
        }
