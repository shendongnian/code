    internal sealed class ThingWrapper {
        private readonly AbstractThing _thing;
        internal ThingWrapper(AbstractThing thing) {
            _thing = thing;
        }
        public String DisplayName { get { return _thing.SomeStringProperty; } }
        internal AbstractThing Thing { get { return _thing; } }
    }
