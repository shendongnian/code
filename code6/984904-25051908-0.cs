    public static class Checklist
    {
        public static List<Reviewer> Reviewers { get; private set; }
        public static bool Validate(object element)
        {
            return true;
        }
        static Checklist()
        {
            Reviewers = new List<Reviewer>();
            Reviewers.Add(new Reviewer((elem)=>true));
        }
    }
    public class Reviewer
    {
        private Func<object, bool> _itsValidator;
        public Reviewer(Func<object,bool> validator)
        {
            _itsValidator = validator;
        }
        public bool Validate(object element)
        {
            return _itsValidator(element);
        }
    }
