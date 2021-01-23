        private bool IsValid(DependencyObject parent)
        {
            if (Validation.GetHasError(parent))
                return false;
            // Validate all the bindings on the children
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (!IsValid(child)) { return false; }
            }
            return true;
        }
