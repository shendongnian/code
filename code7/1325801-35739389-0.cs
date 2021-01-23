    foreach (string item in strFiles)
                    {
                        innerList = item.Split(',');
                        if(!string.IsNullOrEmpty(innerList[0]))
                        {
                            fileList.Add(innerList[0]);
                            fileContents = File.ReadAllText(innerList[0].Replace("\\\\","\\"));
                            if(Regex.IsMatch(fileContents,@"<meta[^>]*name="description"[^>]*content="NOINDEX"[^*]*/>\s*<meta[^>]*name="keywords"[^>]*content="NOINDEX"[^*]*/>"))
                               { Console.WriteLine("string contains strsearch");
    }
                            }
                        }
                    }
