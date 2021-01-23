            var sum = 0;
            var count = 0;
            var averages = new List<double>();
            foreach (var t in numlist)
            {
                if (t > 200)
                {
                    sum += t;
                    count += 1;
                }
                else
                {
                    if (sum == 0) continue;
                    var average = (double) sum/count;
                    averages.Add(average);
                    sum = 0;
                    count = 0;
                }
            }
