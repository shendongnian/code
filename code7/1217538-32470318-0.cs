            //// Join the collection to get the BatchId
            var query = nutritionColl.Join(pupilNutrition, n => n.NutritionId, p => p.NutritionId, (n, p) => new { BatchId = p.Id, Nutrition = n });
            //// Group by BatchId, Operation
            var query1 = query.GroupBy(i => new { i.BatchId, i.Nutrition.Operation });
            //// Execute Used cases by BatchId, Operation
            var query2 = query1.Select(grp =>
                    {
                        decimal rate = decimal.MinValue;
                        if (grp.Count() == 1)
                        {
                            rate = grp.First().Nutrition.NutritionRate;
                        }
                        else if (grp.First().BatchId == 1)
                        {
                            var sum = grp.Sum(i => i.Nutrition.NutritionRate);
                            rate = sum > 10000 ? 10000 : sum;
                        }
                        else
                        {
                            rate = grp.Max(i => i.Nutrition.NutritionRate);
                        }
                        return new { BatchId = grp.First().BatchId, Operation = grp.First().Nutrition.Operation, Rate = rate };
                    }
            );
            //// try out put
            foreach (var item in query2)
            {
                Console.WriteLine("{0}  {1} {2} ", item.Operation, item.BatchId, item.Rate);
            }
