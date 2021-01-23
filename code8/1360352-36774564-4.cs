        private static ICriteriaDetail GetCriteriaDetail(string title, int events, bool hasChild)
        {
            if (!hasChild)
                return new CriteriaDetail(title, events, null);
    
            var child3 = new CriteriaDetail("child3" + title, 13 + events, null);
            var child2 = new CriteriaDetail("child2" + title, 13 + events, new ICriteriaDetail[] { child3 });
            var child1 = new CriteriaDetail("child1" + title, 13 + events, new ICriteriaDetail[] { child2 });
    
    
            return new CriteriaDetail(title, events, new ICriteriaDetail[] {child1});
        }
