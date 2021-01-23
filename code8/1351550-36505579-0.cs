                    if (line != "100")
                    {
                        List<double> doubelowa = new List<double>();
                        doubelowa.AddRange(line.Split().Select(f => double.Parse(f, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture)));
                        lista.Add(doubelowa);
                    }
