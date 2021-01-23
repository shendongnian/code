    public static class HtmlAgilityPackExtensions
    {
        public static void IterateAllNodes(this HtmlDocument doc, Action<HtmlNode> action)
        {
            foreach (var n in doc.DocumentNode.ChildNodes)
            {
                doIterateNode(n, action);
            }
        }
        private static void doIterateNode(HtmlNode node, Action<HtmlNode> action)
        {
            action?.Invoke(node);
            foreach (var n in node.ChildNodes)
            {
                if (n.HasChildNodes)
                {
                    doIterateNode(n, action);
                }
            }
        }
    }
