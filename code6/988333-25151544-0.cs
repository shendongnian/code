    namespace SharedUtilities
    {
        public partial class PartialClass
        {
            public void DoSomethingInteresting(Action<Type1, Type2> action)
            {
                //code logic
                action(p1, p2);
            }
        }
    }
