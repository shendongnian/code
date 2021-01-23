    public class RibbonWindowQuickAccessItemBehaviour : Behavior<RibbonWindow>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += RibbonControl_Loaded;
            AssociatedObject.Closing += RibbonControl_Closing;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= RibbonControl_Loaded;
            AssociatedObject.Closing -= RibbonControl_Closing;
        }
        private void RibbonControl_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var ribbonWindow = (RibbonWindow)sender;
            var ribbon = ribbonWindow.FindAllChildrenOfType<Microsoft.Windows.Controls.Ribbon.Ribbon>().Where(a => a.Name == "ribbon").FirstOrDefault();
            if (ribbon == null) return;
            var dataContext = ribbon.DataContext;
            if (dataContext is IRibbonMainWindowViewModel)
            {
                IRibbon windowsRibbon = (dataContext as IRibbonMainWindowViewModel).WindowRibbon;
                windowsRibbon.QuickAccessMenuItems.Clear();
                if (ribbon.QuickAccessToolBar != null && ribbon.QuickAccessToolBar.Items != null && ribbon.QuickAccessToolBar.Items.Count > 0)
                {
                    foreach (var item in ribbon.QuickAccessToolBar.Items)
                    {
                        if (item is RibbonButton)
                        {
                            var ribbonItem = item as RibbonButton;
                            windowsRibbon.QuickAccessMenuItems.Add
                                (new Gno.Framework.ClientShell.Ribbon.MenuItem(ribbonItem.Label,
                                    ribbonItem.SmallImageSource == null ? string.Empty : ribbonItem.SmallImageSource.ToString(),
                                    ribbonItem.Command));
                        }
                    }
                }
            }
        }
        private void RibbonControl_Loaded(object sender, RoutedEventArgs e)
        {
            var ribbonWindow = (RibbonWindow)sender;
            var ribbon = ribbonWindow.FindAllChildrenOfType<Microsoft.Windows.Controls.Ribbon.Ribbon>().Where(a => a.Name == "ribbon").FirstOrDefault();
            if (ribbon == null) return;
            var dataContext = ribbon.DataContext;
            if (dataContext is IRibbonMainWindowViewModel)
            {
                IRibbon windowsRibbon = (dataContext as IRibbonMainWindowViewModel).WindowRibbon;
                var quickAccessMenus = windowsRibbon.QuickAccessMenuItems;
                if (quickAccessMenus != null && quickAccessMenus.Count > 0)
                {
                    ribbon.QuickAccessToolBar = new RibbonQuickAccessToolBar();
                    foreach (var quickMenu in windowsRibbon.QuickAccessMenuItems)
                    {
                        var ribbonButton = new RibbonButton();
                        ribbonButton.Command = quickMenu.Command;
                        ribbonButton.Label = quickMenu.Header;
                        if (!string.IsNullOrEmpty(quickMenu.ImageUri))
                            ribbonButton.SmallImageSource = new BitmapImage(new Uri(quickMenu.ImageUri));
                        ribbon.QuickAccessToolBar.Items.Add(ribbonButton);
                    }
                }
            }
        }
    }
