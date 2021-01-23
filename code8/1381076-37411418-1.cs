    class Form1
    {
        public static List<string> _myList = new List<string>();
        public void CreateObject()
        {
            var otherObject = new OtherObject();
        }
    }
    class OtherObject
    {
        public OtherObject()
        {  
            Form1._myList.Add("hello");
        }
    }
