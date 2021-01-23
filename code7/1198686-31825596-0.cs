    public class Dohickey
    {
        public void getLicense(bool hasLicense)
        {
            if (!hasLicense) throw new Exception("Ewups");
            SetSomethingThatOtherCodeDependsOn();
            SetSomethingElseAsWell();
        }
    }
