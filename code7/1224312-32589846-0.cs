    public abstract class TestCaseData
    {
        private string id, name;
        public abstract string ID { get; set; }
        public abstract string Name{ get; set; }
    }
    public class DerivedClassOne : TestCaseData
    {
        public override string ID
        {
            get { return id; }
            set
            {
                if ( ... ) throw new ArgumentException();
                if ( ... ) throw new ArgumentException();
                
                ...
                
                id = value;
            }
        }
        ...
    }
