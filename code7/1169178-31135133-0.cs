        public static HtmlNode TruncateInnerText(HtmlNode node, int length)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            // nothing to do?
            if (node.InnerText.Length < length)
                return node;
            HtmlNode clone = node.CloneNode(false);
            TruncateInnerText(node, clone, clone, length);
            return clone;
        }
        private static void TruncateInnerText(HtmlNode source, HtmlNode root, HtmlNode current, int length)
        {
            HtmlNode childClone;
            foreach (HtmlNode child in source.ChildNodes)
            {
                // is expected size is ok?
                int expectedSize = child.InnerText.Length + root.InnerText.Length;
                if (expectedSize <= length)
                {
                    // yes, just clone the whole hierarchy
                    childClone = child.CloneNode(true);
                    current.ChildNodes.Add(childClone);
                    continue;
                }
                // is it a text node? then crop it
                HtmlTextNode text = child as HtmlTextNode;
                if (text != null)
                {
                    int remove = expectedSize - length;
                    childClone = root.OwnerDocument.CreateTextNode(text.InnerText.Substring(0, text.InnerText.Length - remove));
                    current.ChildNodes.Add(childClone);
                    return;
                }
                // it's not a text node, shallow clone and dive in
                childClone = child.CloneNode(false);
                current.ChildNodes.Add(childClone);
                TruncateInnerText(child, root, childClone, length);
            }
        }
