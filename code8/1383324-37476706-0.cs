    class ClassB
    {
        private object Thing {get; set;}
        public void AssignThing(object thing) {Thing = thing;}
    }
    class ClassB<T>:ClassB
    {
        private T Thing { get; set; }
        public void AssignThing(T thing) { Thing = thing; }
    }
    class ClassA
    {
        public List<ClassB<String>> list = new List<ClassB<String>>();
        public ClassA()
        {
            list.Add(new ClassB<String>());
            //Here you only can add ClassB<String>, not ClassB
        }
    }
