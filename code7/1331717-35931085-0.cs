    Guid groupPageId = Guid.NewGuid();
            Guid pageId = Guid.NewGuid();
            initializer.Installer
                .CreateModuleGroupPage(groupPageId, "EmptyCustomModule1 group page")
                    .PlaceUnder(SiteInitializer.SitefinityNodeId)
                    .SetOrdinal(100)
                    .LocalizeUsing<AvalonNotificationsResources>()
                    .SetTitle("Avalon")
                    .SetUrlName("avalon")
                    .ShowInNavigation()
                    .AddChildPage(pageId, "Test Page")
                        .SetOrdinal(1)
                        .LocalizeUsing<AvalonNotificationsResources>()
                        .SetTitle("Test Page")
                        .SetUrlName("test-page")
                        .AddUserControl("~/UserControls/TestWidget.ascx", "Content")
                        .AddControl(new System.Web.UI.WebControls.Literal()
                         {
                             Text = "<h1 class=\"sfBreadCrumb\">Test Widget</h1>",
                             Mode = System.Web.UI.WebControls.LiteralMode.PassThrough
                         })
                        .ShowInNavigation()
                    .Done()
                .Done();
