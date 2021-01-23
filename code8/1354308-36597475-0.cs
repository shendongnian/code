    class Greeting<T> where T : A
    {
       List<T> list;
       public Greeting(List<T> list)
       {
           this.list = new List<T>();
           this.list.AddRange(list);
       }
       public void Show()
       {
          foreach (T el in list)
             el.Greet(); // 'T' does not contain a definition for 'Greet'
       }
    }
