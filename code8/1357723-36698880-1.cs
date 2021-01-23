        public bool testForNotes(Notes n)
        {
            _sqliteConnection.CreateTable<Notes>();
            _sqliteConnection.Insert (n);
            n.Done = true;
            var i = _sqliteConnection.Update (n);
            return (i > 0);
        }
