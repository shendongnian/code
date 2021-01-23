    public class ViewModel
    {
        public class Foo
        {
           public int Id {get;set;}
           public Visibility IsVisible {get;set;}    
        }
        
        private IList<Foo> _fooList;
        public IList<Foo> FooList {get;set;}
        
        private Visibility _parentVisibility;
        public Visibility ParentVisibility{get;set}
    }
