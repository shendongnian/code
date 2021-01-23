    class DocumentState {
        public Dictionary<string, int> State { get; }
        public DocumentState() {
            State = new Dictionary<string, int>() { { "Default", 0 }, { "Draft", 1 }, { "Archived", 2 }, { "Deleted", 3 } };
        }
    }
