        public ViewModel()
        {
            Filter = new FilterGroup();
            Filter.Filters.Add(new PropertyFilter() { PropertyName = "Text", PropertyType = typeof(string) });
            FilterGroup group = new FilterGroup() { Operator = ConditionalOperator.And };
            group.Filters.Add(new PropertyFilter() { PropertyName = "Text2", PropertyType = typeof(string) });
            group.Filters.Add(new PropertyFilter() { PropertyName = "Text3", PropertyType = typeof(string) });
            Filter.Filters.Add(group);
            group = new FilterGroup() { Operator = ConditionalOperator.Or };
            group.Filters.Add(new PropertyFilter() { PropertyName = "Text4", PropertyType = typeof(string) });
            group.Filters.Add(new PropertyFilter() { PropertyName = "Text5", PropertyType = typeof(string) });
            FilterGroup subGroup = new FilterGroup() { Operator = ConditionalOperator.Or };
            subGroup.Filters.Add(new PropertyFilter() { PropertyName = "Text8", PropertyType = typeof(string) });
            subGroup.Filters.Add(new PropertyFilter() { PropertyName = "Text9", PropertyType = typeof(string) });
            group.Filters.Add(subGroup);
            Filter.Filters.Add(group);
            Filter.Filters.Add(new PropertyFilter() { PropertyName = "Text6", PropertyType = typeof(string) });
            Filter.Filters.Add(new PropertyFilter() { PropertyName = "Text7", PropertyType = typeof(string) });
        }
        public FilterGroup Filter { get; set; }
