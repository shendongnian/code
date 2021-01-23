    public static AutomationElement GetFirstDescendant(
        AutomationElement root, 
        Func<AutomationElement.AutomationElementInformation, bool> condition) {
        var walker = TreeWalker.ControlViewWalker;
        var element = walker.GetFirstChild(root);
        while (element != null) {
            if (condition(element.Current))
                return element;
            var subElement = GetFirstDescendant(element, condition);
            if (subElement != null)
                return subElement;
            element = walker.GetNextSibling(element);
        }
        return null;
    }
