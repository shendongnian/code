    class Foo {
        public string name {get;set;}
        public string surname{get;set;}
    }
    return new Foo(){ name = name, surname = surname }
