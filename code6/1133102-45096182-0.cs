    <UserControl
    ...
    <TreeView
        VirtualizingPanel.IsVirtualizing="True"
        VirtualizingPanel.VirtualizationMode="Recycling"/>
    ...
    </UserControl>
    public static class TreeViewHelper
    {
        private static T FindVisualChild<T>(System.Windows.Media.Visual visual) where T : System.Windows.Media.Visual
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                System.Windows.Media.Visual child = (System.Windows.Media.Visual)VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    T correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }
                    T descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }
            return null;
        }
        public static void BringIntoView(TreeViewItem item)
        {
            ItemsControl parent = item.Parent as ItemsControl;
            if (parent != null)
            {
                System.Windows.Controls.VirtualizingStackPanel itemHost = FindVisualChild<System.Windows.Controls.VirtualizingStackPanel>(parent);
                if (itemHost != null)
                {
                    itemHost.BringIndexIntoViewPublic(parent.Items.IndexOf(item));
                    item.Focus();
                }
            }
        }
    }
