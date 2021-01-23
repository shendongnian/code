        public int GetTotalWolves(int day, int personId)
        {
            ObservationId id = new ObservationId(day, personId);
            if (statisztikaDictionary.ContainsKey(id))
            {
                return statisztikaDictionary[id].TotalWolves;
            }
            else
            {
                return 0;
            }
        }
