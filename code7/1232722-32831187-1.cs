        public static List<List<Slots>> GetGroups(List<Slots> slots)
        {
            List<List<Slots>> groups = new List<List<Slots>>();
            DateTime? nextDate = null;
            List<Slots> currentGroup = null;
            foreach (var slot in slots.OrderBy(x => x.StartDate))
            {
                //first time through nextDate and currentGroup are null
                //this condition matches the first time through or any time there is a gap in dates
                if (nextDate == null || nextDate.Value < slot.StartDate)
                {
                    if (currentGroup != null)
                    {
                        //if currentGroups isn't null then we have a completed group
                        groups.Add(currentGroup);
                    }
                    //start a new group
                    currentGroup = new List<Slots>();
                }
                nextDate = slot.EndDate.AddDays(1);
                currentGroup.Add(slot);
            }
            //if there are no items in the collection currentGroup will still be null, otherwise currentGroup has the last group in it still. We finished iterating before finding a gap in dates
            if (currentGroup != null)
            {
                groups.Add(currentGroup);
            }
            return groups;
        }
