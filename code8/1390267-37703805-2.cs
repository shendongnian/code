    public class DoesTwoThingsUsingClassThatDoesFourThings : IDoesTwoThings
    {
        private readonly IDoesFourThings _doesFourThings;
        public DoesTwoThingsUsingClassThatDoesFourThings(IDoesFourThings doesFourThings)
        {
            _doesFourThings = doesFourThings;
        }
        public void DoThingA()
        {
            _doesFourThings.DoThingTwo();
        }
        public void DoThingB()
        {
            _doesFourThings.DoThingThree();
        }
    }
