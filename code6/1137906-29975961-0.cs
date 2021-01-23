    var listOfA = new List<A>();
    var listOfB = new List<A>();
    ... // Code for adding values
    listOfA.ToC(listOfB);
    public static class OuterJoinExtension
    {
        public static List<C> ToC(this List<A> listOfA, List<B> listOfB)
        {
            var listOfC = new List<C>();
            listOfA.ForEach(a => listOfB.ForEach(b =>
            {
                if (b.JoinId == a.JoinId)
                {
                    listOfC.Add(new C { Id = a.Id, JoinId = b.JoinId, Name = b.Name });
                }
            }));
            return listOfC;
        }
    }
