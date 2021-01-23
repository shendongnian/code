            var studentsfullnames = "FirstName1 LastName1, FirstName2 and LastName2, First and Last name of S3";
            // split on full name seperated by comma
            var split1 = studentsfullnames.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            // use a dict with a list. so you can key by word but have multiple strings with the same word
            var dict = new Dictionary<string, List<string>>();
            foreach (var name in split1)
            {
                var temp = name.Replace(",", "").Trim();
                // split on spaces to get individual words.
                var split2 = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in split2)
                {
                    if (dict.ContainsKey(word))
                        dict[word].Add(temp);
                    else
                        dict.Add(word, new List<string> { temp });
                }
            }
