    class Program
    {
        void Run()
        {
            DataGroup WorkingData = new DataGroup();
            Modify("Put This string in here",new FooMethod(),"prop1",WorkingData);
            Modify("This wont do anything", new BarMethod(), "prop5", WorkingData);
        }
        public void Modify(String Input, InterfaceWithData MethodUsed, String Property, DataGroup Data)
        {
            MethodUsed.FooFunction(Input, Property, Data);
        }
    }
    interface InterfaceWithData
    {
        void FooFunction(String Input, String Property, DataGroup Data);
    }
    public class DataGroup
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public string prop3 { get; set; }
        public string prop4 { get; set; }
        public string prop5 { get; set; }
    }
    public class FooMethod :InterfaceWithData
    {
        public void FooFunction(String Input, String Property ,DataGroup Data)
        {
            switch (Property)
            {
                 
                case "prop1":
                    Data.prop1 = Input;
                    break;
                case "prop2":
                    Data.prop2 = Input;
                    break;
                case "prop3":
                    Data.prop1 = Input;
                    break;
                case "prop4":
                    Data.prop3 = Input;
                    break;
                case "prop5":
                    Data.prop5 = Input;
                    break;
                default :
                    throw new System.ArgumentOutOfRangeException("Didnt chose a valid case"); 
            }
        }
    }
    public class BarMethod:InterfaceWithData
    {
        public void FooFunction(String Input, String Property, DataGroup Data)
        {
            Data.prop2 = "Monkey";
            /*Do Something else with the data*/
        }
    }
