        public List<Tuple<string, string, int>> GetHighestTuples(List<Tuple<string, string, int>> tuples, int maxSum)
        {
            int runningTotal = 0;
            var results = tuples
                .OrderByDescending(t => t.Item3)
                .Select(t => new
                    {
                        Item = t,
                        RunningTotal = (runningTotal += t.Item3)
                    })
                .Where(t => t.RunningTotal <= maxSum)
                .Select(t => t.Item)
                .ToList();
            return results;
        }
