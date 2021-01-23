    public List<SubMenuModel> AvailableSubMenu { 
        // Consider sm.Condition is an integer and we want only the positive ones
        get { return SubMenu.FindAll(sm => sm.Condition > 0);
    }
    
