        public bool Consultant(string test, string test2)
        {
            var candidates = db.Consultants.Where(x => x.Test == test && x.Test2 == test2);
            return candidates.AsEnumerable().Any(x => x.Test == test && x.Test2 == test2);
        }
