    public partial class MyDesignerControl : UserControl
    {
        private WorkflowDesigner wd;
        private string workflowFilePathName;
        protected override void OnInitialized(EventArgs e) {
             base.OnInitialized();
             wd = new WorkflowDesigner();
             wd.Load(workflowFilePathName);
             workflowDesignerPanel.Content = wd.View;
             // this doesn't work here:
             // var designerView = wd.Context.Services.GetService<DesignerView>();
        }
        private void MyDesignerControl_Loaded(object sender, RoutedEventArgs e) {
            // here it works:
            var designerView = wd.Context.Services.GetService<DesignerView>();
            // null check, just to make sure it doesn't explode
            if (designerView != null) {
                designerView.WorkflowShellBarItemVisibility =
                         // ShellBarItemVisibility.Imports | <-- Uncomment to show again
                            ShellBarItemVisibility.MiniMap |
                         // ShellBarItemVisibility.Variables | <-- Uncomment to show again
                         // ShellBarItemVisibility.Arguments | <-- Uncomment to show again
                            ShellBarItemVisibility.Zoom;
            }
        }
        
        ...
    }
