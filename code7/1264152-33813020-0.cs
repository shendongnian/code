    public abstract class WeirdPerson() {
        public virtual void DoThis() {
            // base / default implementation as desired
        }
        public virtual void DoThat() { // ditto }
        public abstract void GoWildAndCrazy;
    }
    public class WeirdChild : WeirdPerson {
        public override void DoThis() { // weird child behavior}
        // etc.
    }
    public class WeirdDad : WeirdPerson {
       // override and add methods as needed.
    }
    public class Version_1
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public WeirdPerson WeirdChild { get; protected set; }
        public MysteriousDad Mysterious { get; protected set; }
        public Version_1 (WeirdChild child, string name, int age, MysteriousDad Dad)    {
        }
    }
    public class Version_2 : Version_1 {
        public WeirdPerson WeirdDad 
        public Version_2 (WeirdDad dad, string name, int age, MysteriousDad grandfather) : base (dad, name, age, grandfather) {}
    }
