    class Program {
       public static IContainer Container { get; private set; }
       
       void Main(){
          var builder = new ContainerBuilder();
          ...
          Container = builder.Build();
       }
    }
