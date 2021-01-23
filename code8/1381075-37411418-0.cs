    class Form1
    {
        public List<string> _myList = new List<string>();
        public void CreateObject()
        {
            var otherObject = new OtherObject(this);
        }
    }
    class OtherObject
    {
        public OtherObject(Form1 form)
        {  
            form._myList.Add("hello");
        }
    }
