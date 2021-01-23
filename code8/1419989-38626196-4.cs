        private static Color GetFirstStatusColor(string test)
        {
            List<Status> status = new List<Status>();
            status.Add(new StatusSql());
            status.Add(new StatusInfo());
            int currentMin = -1;
            bool foundOne = false;
            Status firstStatus = null;
            foreach(var stat in status)
            {
                int currStatusIndex = stat.GetIndex(test);
                if ((currStatusIndex < currentMin) || (!foundOne && currStatusIndex != -1))
                {
                    firstStatus = stat;
                    currentMin = currStatusIndex;
                    foundOne = true;
                }
            }
            return firstStatus != null ? firstStatus.Color : Color.White;
        }
