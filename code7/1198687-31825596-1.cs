    [assembly: InternalsVisibleTo("B")]
    // ...
    public class Dohickey
    {
        public void getLicense(bool hasLicense)
        {
            if (!hasLicense) throw new Exception("Ewups");
            SetThings();
        }
        internal void SetThings()
        {
            SetSomethingThatOtherCodeDependsOn();
            SetSomethingElseAsWell();
        }
    }
