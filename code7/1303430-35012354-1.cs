    public class SelectCollection
    {
        public static IEnumerable<Expression<Func<Evaluation, bool>>> Evaluation
        {
            get
            {
                yield return (e) => e.Status == Status.New;
                yield return (e) => e.Id == 0;
            }
        }
    }
