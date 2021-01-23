    var loops = 1000000;
                var arrayExisting = Enumerable.Repeat(-1, 1000).ToArray();
                var replacements = Enumerable.Repeat(1, 1000).ToArray();
                var selectTimer = Stopwatch.StartNew();
                for (var j = 0; j < loops; j++)
                {
                    var i = 0;
                    var newArray = arrayExisting.Select(val =>
                    {
                        if (val != -1) return val;
                        var ret = replacements[i];
                        i++;
                        return ret;
                    }).ToArray();
                }
                selectTimer.Stop();
                var forTimer = Stopwatch.StartNew();
                for (var j = 0; j < loops; j++)
                {
                    var replaced = new int[arrayExisting.Length];
                    int replacementIndex = 0;
                    for (var i = 0; i < arrayExisting.Length; i++)
                    {
                        if (arrayExisting[i] < 0)
                        {
                            replaced[i] = replacements[replacementIndex++];
                        }
                        else
                        {
                            replaced[i] = arrayExisting[i];
                        }
                    }
                }
                forTimer.Stop();
                Console.WriteLine("Select: " + selectTimer.ElapsedMilliseconds);
                Console.WriteLine("For: " + forTimer.ElapsedMilliseconds);
