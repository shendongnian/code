    var controller = new DotNetNuke.Entities.Tabs.TabController();
    var tabs = controller.GetTabsByPortal(PortalSettings.PortalId)
        .Where(t => DotNetNuke.Security.Permissions.TabPermissionController.CanViewPage(t.Value))
        .Select(t => t.Value);
    
