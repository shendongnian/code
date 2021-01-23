        public static List<List<Slots>> GetGroups(List<Slots> slots)
        {
            List<List<Slots>> groups = new List<List<Slots>>();
            DateTime? nextDate = null;
            List<Slots> currentGroup = null;
            foreach (var slot in slots.OrderBy(x => x.StartDate))
            {
                if (nextDate == null || nextDate.Value < slot.StartDate)
                {
                    if (currentGroup != null)
                    {
                        groups.Add(currentGroup);
                    }
                    currentGroup = new List<Slots>();
                }
                nextDate = slot.EndDate.AddDays(1);
                currentGroup.Add(slot);
            }
            if (currentGroup != null)
            {
                groups.Add(currentGroup);
            }
            return groups;
        }
