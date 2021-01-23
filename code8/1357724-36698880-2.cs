        public void GetNotes ()
        {
            NoteDataStore _noteDataStore = new NoteDataStore (new SqlConnection());
            var note = new Notes () {
                Name = "TestName",
                Note = "TestNote",
                Date = DateTime.Now.ToString (),
                Done = false
            };
            var show = _noteDataStore.testForNotes (note);
            Assert.IsNotNull (show);
        }
