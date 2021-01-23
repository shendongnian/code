    public class FileCompareUIFactory{
    // pseudo code, needs work
      private Dictionary<Type,Type> registered = new {
        { typeof(FileCompareNames), typeof(FileCompareNamesUIView)}
      }
      public void Register<C,V> where C: IFileCompare, V: View{
        registered[typeof(C)] = typeof(V);
      }
    
      public V GetView<C,V>() where C:IFileCompare, V: View {
        // cache already instantiated if needed
        return (V)(Activator.CreateInstance(registered[typeof(C)])
      }
    }
