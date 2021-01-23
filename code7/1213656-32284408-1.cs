    [Serializable]
    public class SomeData
    {
        public Double Value {get;set;}
        public override string ToString()
        {
           return String.Format("Awesome! {0}", Value );
        }
    }
