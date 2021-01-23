        private void SeeTheChild()
        {
            DataGrid myCombo = GetVisualChildInDataTemplate<DataGrid>(lstIndent);            
        }
        private T GetVisualChildInDataTemplate<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChildInDataTemplate<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
