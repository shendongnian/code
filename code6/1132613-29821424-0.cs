    interface ISetVisibility {
        public Visibility Visibilty {set;}
    }
    class MyDerived : MyBase, ISetVisibility {
        public Visibility ISetVisibilty.Visibility { set {/* ... */ } }
    }
