        public class Project    
        {
            public DateTime? Date;
            public string ImportanceLevel;
        }
        var sortedProejcts =
                projects.OrderByDescending(p => p.Date.HasValue)
                .ThenBy(p => Math.Abs(DateTime.Now.CompareTo(p.Date ?? DateTime.MaxValue)))
                .ThenByDescending(
                    p =>
                    {
                        switch (p.ImportanceLevel)
                        {
                            case "Low":
                                return 1;
                            case "Medium":
                                return 2;
                            case "High":
                                return 3;
                            default:
                                return 0;
                        }
                    });
