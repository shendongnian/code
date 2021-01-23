        static void Main(string[] args)
        {
            List<List<string>> arrayoflists = new List<List<string>> { new List<string> { "1" }, new List<string> { "2" } };
            List<MyModel> myModelsList = arrayoflists.Select<List<string>,MyModel>(x =>
            {
                MyModel model = new MyModel();
                model.MyList = (List<string>)x;
                return model;
            }).ToList();
        }
    }
    public class MyModel
    {
        private List<string> _myList;
        public List<string> MyList
        {
            get { return _myList; }
            set { _myList = value; doSomething(); }
        }
        private void doSomething() {
            Console.WriteLine(_myList[0]);
        }
    }
