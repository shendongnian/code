        public static decimal CalculateRate(int pupilId, int batchId)
        {
            return NutritionTable
                .Where(x => x.BatchId == batchId && PupilNutritionTable.Any(y => y.PupilId == pupilId && y.NutritionId == x.NutritionId))
                .GroupBy(x => x.Operation)
                .Select(CalculateRateForOperationGroup)
                .Sum();
        }
        
        public static decimal CalculateRateForOperationGroup(IGrouping<int, Nutrition> group)
        {
            switch (group.Key)
            {
                case 0:
                    // Rate = Sum(x)
                    return group.Sum(x => x.NutritionRate);
                case 1:
                    // Rate = Min(10000, Sum(x))
                    return Math.Min(10000, group.Sum(x => x.NutritionRate));
                case 2:
                    // Rate = -Max(x)
                    return -group.Max(x => x.NutritionRate);
                default:
                    throw new ArgumentException("operation");
            }
        }
