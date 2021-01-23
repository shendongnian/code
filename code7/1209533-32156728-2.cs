            string lyrsct = drow1["lyricist"].ToString();
            var delimiters = new[] { ',' };
            var lyrsct1 = lyrsct.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList(); // List is modifiable.
            for (int i = 0; i < lyrsct1.Length; i++)
            {
                var item = lyrsct1[i];
                if ()
                { 
                    int indexToRemove = something; // index of item that should be removed
                    lyrsct1.Remove(indexToRemove);
                    if(indexToRemove <= i) i--; // correct the indexing
                }
            }
