        public InvestigatorGroup GetCommonGroup(string userId, string investigatorUserId)
        {
            using (GameDbContext entityContext = new GameDbContext())
            {
                IEnumerable<InvestigatorGroup> userGroups = entityContext.InvestigatorGroups
                    .Where(i => i.IsTrashed == false)
                    .Include(i => i.InvestigatorGroupUsers)
                    .Where(i => i.InvestigatorGroupUsers.Any(e => e.UserId.Contains(userId)))
                    .OrderByDescending(i => i.InvestigatorGroupId);
                return userGroups.Where(i => i.InvestigatorGroupUsers.Any(e => e.UserId.Contains(investigatorUserId))).FirstOrDefault();
            }
        }
