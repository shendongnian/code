                int tryCount = 1;
                string pathFormat = "c:\\test{0}.csv";
                while (tryCount <= MAX_TRYCOUNT)
                {
                    try
                    {
                        using (FileStream fs = File.Open(String.Format(CultureInfo.InvariantCulture, pathFormat, tryCount), FileMode.CreateNew))
                        {
                            //fs.Write or open StreamWriter etc.
                        }
                    }
                    catch (IOException)
                    {
                        /* try next filename */
                    }
                    catch (Exception ex)
                    {
                        /* other unexpected error, escape. */
                        throw;
                    }
                    tryCount++;
                }
                if (tryCount == MAX_TRYCOUNT)
                {
                    throw new IOException("No free filename available.");
                }
