    class BaseClass {
        protected List<Field> list = new List<Field>();
        public BaseClass()
        {           
           list.add(new Field(){name = "fieldNameA", type = "typeA"});
           list.add(new Field(){name = "fieldNameB", type = "typeB"});
           list.add(new Field(){name = "fieldNameC", type = "typeC"});
        }
    }
    class SubClass : BaseClass {
        public SubClass() : base()  
        {           
           list.add(new Field(){name = "fieldNameD", type = "typeD"});
           list.add(new Field(){name = "fieldNameE", type = "typeE"});
        }
    }
