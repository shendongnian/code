    CurrentMessagesForGroup = CurrentMessage
                            .Where(c => c.GroupName == groupName)
                            .OrderBy(c => c.GroupName)
                            .Take(5)
                            .ToList();
