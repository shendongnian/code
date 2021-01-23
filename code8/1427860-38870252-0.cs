    public class TheViewModel
    {
        public void SetTheType(Type theType)
        {
            Inputs.Clear();
            foreach (var prop in theType.GetProperties())
            {
                if (prop.PropertyType == typeof(DateTime)
                {
                    Inputs.Add(new DateTimeInput...); // create the descriptors here
                }
                // other known types here
            }
        }
        public IList<InputBase> Inputs{get; private set;}
    }
    
    public class InputBase
    {
    }
    public class DateTimeInput : InputBase
    {
        DateTime Value {get;set}
    }
