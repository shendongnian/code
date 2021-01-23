    public void SetSelectedItem(string itemName, ITimeout timeout = null)
    {
    	this.GetSelf(timeout).Expand();
    
    	var list = this.GetSelf(timeout).FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List), timeout);
    	var listItem = list.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, itemName), timeout);
    	
    	listItem.Select();
    }
