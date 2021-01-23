            HidePreviewTabFromCRV();
        }
        private void HidePreviewTabFromCRV()
        {
            //visiual Tree
            var y = GetChild<System.Windows.Controls.Primitives.TabPanel>(CrystalReportsViewer1.ViewerCore);
            y.Visibility = Visibility.Collapsed;
        }
        private TargetType GetChild<TargetType>(DependencyObject o)
           where TargetType : DependencyObject
        {
            if (o == null || o is TargetType)
                return (TargetType)o;
            int i = 0;
            if (VisualTreeHelper.GetChildrenCount(o) == 2 && VisualTreeHelper.GetParent(o).GetType() == typeof(TabControl))
                i = 1; // We Arrive Our Destination
            return GetChild<TargetType>(VisualTreeHelper.GetChild(o,i));
        }
