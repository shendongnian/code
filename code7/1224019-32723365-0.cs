        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //check if the item is an instance of TestViewModel
            if (item is TestViewModel)
                return TheTemplate;
            //delegate the call to base class
            return base.SelectTemplate(item, container);
        }
