    foreach(HtmlNode child in table.ChildNodes)
    {
        if (child.NodeType != HtmlNodeType.Text)
        {
            Console.WriteLine(child.Name);
        }
    }
