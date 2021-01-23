    public class TheFlu : ITreatable
    {
        public Treatment GetTreatment(int year)
        {
            // return some object, Treatment, based on the flu season.
        }
    }
    public class Hangover : ITreatable
    {
        public Treatment GetTreatment()
        {
            return Treatment.Empty; // no parameters necessary.
        }
    }
    public class Insomnia : ITreatable
    {
        public Treatment GetTreatment(FamilyHistory occurances, LabResult lab)
        {
            // return Some Treatment object that can be different based on the
            // calculated risk from the arguments.
        }
    }
