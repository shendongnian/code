        public DependencyObject this[string childName]
        {
            get
            {
                return innerPanel.FindChild<DependencyObject>(childName);
            }
        }
