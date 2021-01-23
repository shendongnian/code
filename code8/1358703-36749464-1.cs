    public class Class1{
        public void DoStuff(IEnumerable<T> collection){
            PreCondition.NotIsOrHasNull(collection);
            foreach (var x in collection){
                //Stuff
            }
        }
    }
