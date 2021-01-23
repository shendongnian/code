    public class TestableDocument : Document {
        DocumentState _state;
        bool first = true;
        public TestableDocument(DocumentState state) {
            _state = state;
        }
        public override DocumentState State {
            get {
                if (first) {
                    first = false;
                    return _state;
                }
                return base.State;
            }
        }
    }
