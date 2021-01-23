        private static string[] _arr = new string[] // The stuff you read from file.
        private static List<string[]> _arrays = new List<string[]>(); 
            while (_arr.Length > 0)
            {
                var a = _arr.TakeWhile(s =>
                {
                    var li = _arr.ToList();
                    return 
                        s != string.Empty // Take it if the string isn't empty.
                        || (s == string.Empty && li.IndexOf(s) == 0) // Or if it's empty, but it's the first element in the array (it's the next one after we've just finished a batch)
                        || li.IndexOf(s) == _arr.Length; // And take it if it's the last element (in the case of an empty string as the last element)
                }).ToArray();
                _arrays.Add(a);
                // Re-create the array to only include the stuff we haven't solved yet.
                var l = _arr.ToList();
                l.RemoveRange(0, a.Length);
                _arr = l.ToArray();
            }
