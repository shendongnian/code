    public class TheClass
    {
        private readonly Guid _identifier;
        private EventGenerator _eventGenerator;
        // The constructor is given the event generator class instance
        public TheClass(EventGenerator evGen)
        {
            // create a unique identifier for the class
            _identifier = Guid.NewGuid();
            // subscribe to the event
            _eventGenerator = evGen;
            _eventGenerator.TheEvent += TheEvent;
        }
        private void TheEvent(object sender, MyEventArgs e)
        {
            // when the event fires, check the Guid and if it isn't a match, don't continue ...
            if (e.Identifier == _identifier) return;
            // rest of the handler goes here ...
        }
    }
