        static public XElement removeNilAttributes(XElement root)
        {
            root.DescendantsAndSelf().Attributes(xsi + "nil").Remove();
            return root;
        }
