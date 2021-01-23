    public class TheMainObject
    {
        public TheMainObject(dynamic obj)
        {
            if (obj is IA)
            {
                // work with IA ...
            }
            else if (obj is IB)
            {
                // work with IB ...
            }
            else
            {
                // exception ...
            }
        }
    }
