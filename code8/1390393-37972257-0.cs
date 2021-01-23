    public class A<T> : I
    {
         IEnumerable<T> items;
         public IEnumerable<object> Enumers
         {
             get
			 {
				foreach(var item in items)
				{
					yield return (object)item;
				}
			 }
         }
    }
