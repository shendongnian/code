        public static List<string> GetMilestoneNames(XDocument doc, string branchName)
        {
            var query = doc.Root.Descendants("branch")
                .Where(e => e.Attributes("name").Any(a => a.Value == branchName))
                .Elements("milestones")
                .Elements("milestone")
                .Attributes("name").Select(a => a.Value);
            return query.ToList();
        }
