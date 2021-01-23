     class Program
    {
        enum Status { Registered, Submitted, Denied }
        static void Main(string[] args)
        {
            int currentRating = 91;
            RatingTrigger RatingTrigger = new RatingTrigger();
            StateMachine<Status, Trigger> _sm = new StateMachine<Status, Trigger>(Status.Registered);
            _sm.Configure(Status.Registered)
                .PermitIf(RatingTrigger, Status.Submitted, () => RatingTrigger.Guard(currentRating), RatingTrigger.GuardDescription)
                .PermitIf(RatingTrigger, Status.Denied, () => RatingTrigger.Guard(currentRating), RatingTrigger.GuardDescription);
            var list = _sm.PermittedTriggers;
            foreach (var item in list)
            {
                if (item.GetType().Equals(typeof(RatingTrigger)))
                {
                    Console.WriteLine(((RatingTrigger)item).GuardDescription);
                }
                else
                Console.WriteLine(item);
            }
        }
        private static bool evaluate()
        {
            return true;
        }
    }
    public abstract class Trigger
    {
        public abstract bool Guard(object something);
    }
    public class RatingTrigger : Trigger
    {
        public string GuardDescription = "This Guard evaluaties the current rating. Retuns true if good rating, false if bad rating";
        public override bool Guard(object rating)
        {
             return  (((int)rating) > 90);
        }
    }
