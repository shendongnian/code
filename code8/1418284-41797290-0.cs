    public class DrawerHostEx : DrawerHost
    {
        public DrawerHostEx()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var grid = GetTemplateChild(TemplateContentCoverPartName) as System.Windows.Controls.Grid;
            grid.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
