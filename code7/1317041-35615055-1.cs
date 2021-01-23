        public static List<AttributeWeightPair<decimal>> WeightLimiter(List<AttributeWeightPair<decimal>> source, decimal weightLimit)
        {
            weightLimit /= 100; //convert to percentage
            var zeroWeights = source.Where(w => w.Weight == 0).ToList();
            var nonZeroWeights = source.Where(w => w.Weight > 0).ToList();
            if (nonZeroWeights.Count == 0)
                return source;
            //return equal weights if given infeasible constraint
            if ((1m / nonZeroWeights.Count()) > weightLimit)
            {
                nonZeroWeights.ForEach(w => w.Weight = 1);
                return nonZeroWeights.Concat(zeroWeights).ToList();
            }
            //return original list if weight-limiting is unnecessary
            if ((nonZeroWeights.Max(w => w.Weight) / nonZeroWeights.Sum(w => w.Weight)) <= weightLimit)
            {
                return source;
            }
            //sort (ascending) and store original weights
            nonZeroWeights = nonZeroWeights.OrderBy(w => w.Weight).ToList();
            var originalWeights = nonZeroWeights.Select(w => w.Weight).ToList();
            //set starting point and determine direction from there
            var initialSumWeights = nonZeroWeights.Sum(w => w.Weight);
            var initialLimit = weightLimit * initialSumWeights;
            var initialSuspects = nonZeroWeights.Where(w => w.Weight > initialLimit).ToList();
            var initialTarget = weightLimit * (initialSumWeights - (initialSuspects.Sum(w => w.Weight) - initialLimit * initialSuspects.Count()));
            var antepenultimateIndex = Math.Max(nonZeroWeights.FindLastIndex(w => w.Weight <= initialTarget), 1); //needs to be at least 1        
            for (int i = antepenultimateIndex; i < nonZeroWeights.Count(); i++)
            {
                nonZeroWeights[i].Weight = originalWeights[antepenultimateIndex - 1]; //set cap equal to the preceding weight
            }
            bool goingUp = (nonZeroWeights[antepenultimateIndex].Weight / nonZeroWeights.Sum(w => w.Weight)) > weightLimit ? false : true;
            //Procedure 1 - find the weight # at which a cap would result in a weight % just UNDER the weight limit
            int penultimateIndex = antepenultimateIndex;
            bool justUnderTarget = false;          
            while (!justUnderTarget)
            {
                for (int i = penultimateIndex; i < nonZeroWeights.Count(); i++)
                {
                    nonZeroWeights[i].Weight = originalWeights[penultimateIndex - 1]; //set cap equal to the preceding weight
                }
                var currentMaxPcntWeight = nonZeroWeights[penultimateIndex].Weight / nonZeroWeights.Sum(w => w.Weight);
                if (currentMaxPcntWeight == weightLimit) 
                {
                    return nonZeroWeights.Concat(zeroWeights).ToList();
                }
                else if (goingUp && currentMaxPcntWeight < weightLimit)
                {
                    nonZeroWeights[penultimateIndex].Weight = originalWeights[penultimateIndex]; //reset
                    if (penultimateIndex < nonZeroWeights.Count() - 1)
                        penultimateIndex++; //move up
                    else break;
                }
                else if (!goingUp && currentMaxPcntWeight > weightLimit)
                {
                    if (penultimateIndex > 1)
                        penultimateIndex--; //move down
                    else break;
                }
                else
                {
                    justUnderTarget = true;
                }
            }
            if (goingUp) //then need to back up a step
            {
                penultimateIndex = (penultimateIndex > 1 ? penultimateIndex - 1 : 1);
                for (int i = penultimateIndex; i < nonZeroWeights.Count(); i++)
                {
                    nonZeroWeights[i].Weight = originalWeights[penultimateIndex - 1];
                }
            }
            //Procedure 2 - increment the modified weights (subject to a cap equal to their original values) until the weight limit is hit (allowing a very slight overage for the last term in some cases)
            int ultimateIndex = penultimateIndex;
            var sumWeights = nonZeroWeights.Sum(w => w.Weight); //use this counter instead of summing every time for condition check within loop
            bool justOverTarget = false;
            while (!justOverTarget)
            {
                for (int i = ultimateIndex; i < nonZeroWeights.Count(); i++)
                {
                    if (nonZeroWeights[i].Weight + 1 > originalWeights[i])
                    {
                        if (ultimateIndex < nonZeroWeights.Count() - 1)
                            ultimateIndex++;
                        else justOverTarget = true;
                    }
                    else
                    {
                        nonZeroWeights[i].Weight++;
                        sumWeights++;
                    }
                }
                if ((nonZeroWeights.Last().Weight / sumWeights) >= weightLimit)
                {
                    justOverTarget = true;
                }
            }
            return nonZeroWeights.Concat(zeroWeights).ToList();
        }
        public class AttributeWeightPair<T>
        {
            public T Attribute { get; set; }
            public decimal? Weight { get; set; }
            public AttributeWeightPair(T attribute, decimal? count)
            {
                this.Attribute = attribute;
                this.Weight = count;
            }
        }
