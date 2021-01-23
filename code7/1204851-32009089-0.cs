    public partial class DataContext
    {
         public someResult UpdatePerson(Person p)
         {
             return this.UpdatePerson(p.Name, p.Age);
         }
    }
