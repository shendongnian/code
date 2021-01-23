    public static AutomationElement GetFirstChild(
        AutomationElement root,
        Func<AutomationElement.AutomationElementInformation, bool> condition) {
        var walker = TreeWalker.ControlViewWalker;
        var element = walker.GetFirstChild(root);
        while (element != null) {
            if (condition(element.Current))
                return element;
            element = walker.GetNextSibling(element);
        }
        return null;
    }
