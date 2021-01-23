            using (var fs = new FileStream("C:\\test.txt", FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    int nRead = 0;
                    while (nRead < settings.Total)
                    {
                        for (int i = 0; i < settings.ReadLimit && nRead < settings.Total; ++i, nRead++)
                        {
                            Console.WriteLine(sr.ReadLine());
                            if (i + 1 < settings.ReadLimit)
                            {
                                Thread.Sleep(settings.Delay * 1000);
                            }
                        }
                        if (nRead < settings.Total)
                        {
                            Thread.Sleep(settings.GlobalDelay * 1000);
                        }
                    }
                }
            }
