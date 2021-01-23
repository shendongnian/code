        public static Profile readFile(string filename)
        {
            var profile = new Profile();
            var properties = typeof(Profile).GetProperties().ToDictionary(q => q.Name, q => q);
            using (StreamReader sr = new StreamReader(filename))
            {
                String mode = "";
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    if (line == "[Student]")
                    {
                        mode = "student";
                        // and I am stuck here, not sure how to find 
                        // the next lines, so i can take the values
                        // and put them in the profile 
                    }
                    else if (line == "[Teacher]")
                    {
                        mode = "teacher";
                    }
                    else if (!string.IsNullOrEmpty(line))
                    {
                        var nameValues = line.Split(new char[] { '=' }, 2);
                        if (nameValues.Length < 2)
                            continue;
                        var key = mode + nameValues[0];
                        
                        if (properties.ContainsKey(key))
                        {
                            var value = nameValues[1];
                            properties[key].SetValue(profile, value);
                        }
                    }
                }
            }
            return profile;
        }
