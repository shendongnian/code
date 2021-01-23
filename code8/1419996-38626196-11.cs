    public class StatusList : List<Status>
    {
        public Status GetFirstFoundStatus(string lookup)
        {
            int currentMin = -1;
            bool foundOne = false;
            Status firstStatus = null;
            foreach (var stat in this)
            {
                int currStatusIndex = stat.GetIndex(lookup);
                if ((currStatusIndex < currentMin) || (!foundOne && currStatusIndex != -1))
                {
                    firstStatus = stat;
                    currentMin = currStatusIndex;
                    foundOne = true;
                }
            }
            return firstStatus;
        }
    }
