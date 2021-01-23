    interface IFactory<T> where T : A {
       T Construct(object param1, object param2)
    }
    class BFactory : IFactory<B> {
       public B Construct(object param1, object param2) {
           return new B(param1, param2);
       }
    }
    void Save<T>(T target, IFactory<T> tFactory) where T : A {
       T newT = tFactory.Construct(a, b);
    }
