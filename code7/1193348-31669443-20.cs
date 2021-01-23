    interface ISerializer<T> : IDisposable
    {
       virtual byte[] Serialize(T instance); 
       virtual T DeSerialize(byte[] stream);
    }
    Class MySerializer<T> : ISerializer<T>
    {
       public override byte[] Serialize(object instance)
       {
          // .. serialization logic
       }
    
       public override T DeSerialize(byte[] stream)
       {
          // .. deserialization logic
       }
       public void Dispose()
       {
          // .. dispose all managed resources here
       }
    }
    class MyClass
    {
    }
