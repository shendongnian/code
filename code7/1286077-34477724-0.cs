        public class Project    
        {
            public DateTime? Date;
            public ImportanceLevelEnum ImportanceLevel;
        }
        public enum ImportanceLevelEnum
        {
            High = 30,
            Medium = 20,
            Low = 10
        }
        var sortedProejcts =
                projects.OrderBy(p => Math.Abs((p.Date ?? DateTime.MaxValue).CompareTo(DateTime.Now))).ThenByDescending(p => p.ImportanceLevel);
