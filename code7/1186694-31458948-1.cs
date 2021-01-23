        private void Window_Activated(object sender, EventArgs e)
        {
            List<GridViewColumnHeader> headers = GetVisualChildren<GridViewColumnHeader>(DownloadList).ToList();
            GridViewSort.ApplySort(DownloadList.Items, "File Name", DownloadList, headers[10]);
        }
        public static IEnumerable<T> GetVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                    yield return (T)child;
                foreach (var descendant in GetVisualChildren<T>(child))
                    yield return descendant;
            }
        }
