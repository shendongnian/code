    public A<T> FactoryMethod<T>(int i)
    {
       if(i == 1)
          return new A<T>():
       if(i == 2)
          return new B<T>():
       if(i == 3) 
          return (A<T>)(object)new C():
          // The cast to object gets rid of compile time checking,
          // but will throw an InvalidCastExceptoin if T is not D
    }
