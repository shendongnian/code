    public static class ExtensionMethods {
        public static int GetDepth(this XElement element) {
            if (element.Parent == null)
                return 0;
            return element.Parent.GetDepth() + 1;
        }
    }
