                    Dictionary<int, int> dict = new Dictionary<int, int>();
                    dict.Add(1, 10);
                    dict.Add(2, 20);
                    dict.Add(3, 30);
                    dict.Add(4, 40);
                    double coe1 = 1;
                    double series = 1;
                    foreach (var number in dict)
                    {
                        coe1 *= number.Value;
                        series *= (1 - number.Value);
                    }
                    double x = coe1 / (coe1 + series);
