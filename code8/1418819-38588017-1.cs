    CurrentMessagesForGroup = CurrentMessage
                            .Where(c => c.GroupName == groupName)
                            .OrderByDescending(c => c.GroupName)
                            .Take(5)
                            .ToList();
