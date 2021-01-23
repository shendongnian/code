    public abstract class Version_X {
        // all the original properties here.
        // virtual and abstract methods as needed
       // LOOK! standard-issue constructor!
       protected Version_X ( WeirdPerson person, ...) { // common validation, etc. }
    }
    public class Version_1 : Version_X {
        public Version_1( WeirdChild child, ... ) : base ( child, ... ) {}
    }
    public class Version_2 : Version_X {
        public Version_2 ( WeirdDad dad, ... ) {}
    }
