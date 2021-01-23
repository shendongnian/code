    var scores = new Dictionary<string, List<int>>(); 
                    var rawScores = new List<string>();
                    rawScores.ForEach(raw =>
                    {
                        var split = raw.Split(',');
                        if (scores.Keys.All(a => a != split[0]))
                        {
                            scores.Add(split[0], new List<int> {Convert.ToInt32(split[1])});
                        }
                        else
                        {
                            var existing = scores.FirstOrDefault(f => f.Key == split[0]);
                            existing.Value.Add(Convert.ToInt32(split[1]));
                        }
                    });
