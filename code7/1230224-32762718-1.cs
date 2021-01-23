        public bool Consultant(string test, string test2)
        {
            var candidates = db.Consultants.Where(x => x.Test == test && x.Test2 == test2);
            return candidates.AsEnumerable().Any(x => x.Test == test && x.Test2 == test2);
        }
     Don't forget to add comments if you use this approach, since this is hardly intuitive.
