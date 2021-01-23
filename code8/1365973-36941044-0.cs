    // Extract The filecode 
                        const string pattern = @"files\/detail\/(.*)'>";
                        // Instantiate the regular expression object.
                        var r = new Regex(pattern, RegexOptions.IgnoreCase);
                        // Match the regular expression pattern against a text string.
                        var m = r.Match(fileUpdate.UpdateText);
                        if (m.Success && m.Groups.Count == 2 )
                        {
                            m.Groups[1].Value; // This is the expected result 
                        }
