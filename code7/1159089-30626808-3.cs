    public class Manager {
       public Item Create() {
          ...
    #pragma warning disable 618
          return new Item(...);
    #pragma warning restore 618
       }
    }
