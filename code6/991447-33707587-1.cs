    nodeHandlers.Add("li", (node, parent) =>
    {
        var listStyle = node.ParentNode.Name == "ul"
            ? "UnorderedList"
            : "OrderedList";
        var section = (Section)parent;
        var isFirst = node.ParentNode.Elements("li").First() == node;
        var isLast = node.ParentNode.Elements("li").Last() == node;
        var listItem = section.AddParagraph().SetStyle(listStyle);
        if (listStyle == "UnorderedList")
        {
            listItem.Format.ListInfo.ListType = _nestedListLevel%2 == 1 ? ListType.BulletList2 : ListType.BulletList1;
        }
        else
        {
            listItem.Format.ListInfo.ListType = _nestedListLevel % 2 == 1 ? ListType.NumberList2 : ListType.NumberList1;
        }
                
        if (_nestedListLevel > 0)
        {
            listItem.Format.LeftIndent = String.Format(CultureInfo.InvariantCulture, "{0}in", _nestedListLevel*.75);
        }
        // disable continuation if this is the first list item
        listItem.Format.ListInfo.ContinuePreviousList = !isFirst;
        if (isLast)
            _nestedListLevel--;
                
        return listItem;
    });
