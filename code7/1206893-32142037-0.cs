    public static void SelectDropdownItem(AutomationElement dropdownBox, string itemToSelect, bool navigateToParent = true)
    {
            var expandCollapsePattern = (ExpandCollapsePattern)dropdownBox.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern);
            expandCollapsePattern.Expand();
            expandCollapsePattern.Collapse();
            var listItem = dropdownBox.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, itemToSelect));
            if (navigateToParent)
            {
                var controlViewWalker = TreeWalker.ControlViewWalker;
                listItem = controlViewWalker.GetParent(listItem);
            }
            object selectionItemPattern;
            if (listItem.TryGetCurrentPattern(SelectionItemPattern.Pattern, out selectionItemPattern))
            {
                var selectPattern = (SelectionItemPattern)selectionItemPattern;
                selectPattern.Select();
            }
    }
