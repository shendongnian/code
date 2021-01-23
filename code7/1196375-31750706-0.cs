        protected class PendingChanges
        {
            protected class PendingChange
            {
                public Guid punchId { get; set; }
                public DateTime Date { get; set; }
                public string Time { get; set; }
            }
            private List<PendingChange> pendingChanges;
            public PendingChanges()
            {
                pendingChanges = new List<PendingChange>();
            }
            public void Add(Guid guid, DateTime date)
            {
                foreach (PendingChange change in pendingChanges)
                {
                    // Exists in table
                    if (change.punchId == guid)
                    {
                        change.Date = date;
                        return;
                    }
                }
                // Record doens't exist, add it
                PendingChange newChange = new PendingChange();
                newChange.punchId = guid;
                newChange.Date = date;
                pendingChanges.Add(newChange);
            }
            public void Add(Guid guid, string time)
            {
                foreach (PendingChange change in pendingChanges)
                {
                    // Exists in table
                    if (change.punchId == guid)
                    {
                        change.Time = time;
                        return;
                    }
                }
                // Record doens't exist, add it
                PendingChange newChange = new PendingChange();
                newChange.punchId = guid;
                newChange.Time = time;
                pendingChanges.Add(newChange);
            }
            public DateTime? LookupDate(Guid guid)
            {
                foreach (PendingChange change in pendingChanges)
                {
                    if (change.punchId == guid)
                    {
                        return change.Date;
                    }
                }
                return null;
            }
            public string LookupTime(Guid guid)
            {
                foreach (PendingChange change in pendingChanges)
                {
                    if (change.punchId == guid)
                    {
                        return change.Time;
                    }
                }
                return null;
            }
            public void Delete(Guid guid)
            {
                foreach (PendingChange change in pendingChanges)
                {
                    if (change.punchId == guid)
                    {
                        pendingChanges.Remove(change);
                        return;
                    }
                }
            }
        }
