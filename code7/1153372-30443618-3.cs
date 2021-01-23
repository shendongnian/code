    class RankTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EmployeeTemplate { get; set; }
        public DataTemplate CustomerTemplate { get; set; }
        public DataTemplate ClubMemberTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            if (item is Employee) return EmployeeTemplate;
            if (item is Customer) return CustomerTemplate;
            if (item is ClubMember) return ClubMemberTemplate;
            throw new ArgumentException("The type of the item is not recognized", "item");
        }
    }
