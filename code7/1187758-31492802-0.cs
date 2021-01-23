    public abstract class Test
    {
        protected int _number;
        [System.ComponentModel.DataAnnotations.Range(0, 10)]
        public abstract int NumProp
        {
            get;
            set;
        }
    }
    public class Test2 : Test
    {
        [System.ComponentModel.DataAnnotations.Range(100, 1000)]
        public override int NumProp
        {
            get{
                return _number;
            }
            set
            {
                _number = value;
            }
        }
    }
