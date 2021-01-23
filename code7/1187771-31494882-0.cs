    public class ClassA : IClassA
    {
        public ClassA() {}
        public void  GetClientData()
        {
            ClassB b = new ClassB(this);
            string result=  b.GetDataFromDB("c1");
        }
        public void StartProcess(string d)
        {
            string data = d; 
        }
    }
