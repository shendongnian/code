    public class AccountBL<T> where T : BaseAccount, new()
    {
        public void TestMethod()
        {
            T obj1 = new T();
            obj1.MyMethod1();
            if (obj1 is DerivedAccount )
            {
                 (obj1 as DerivedAccount).MyMethod2();
            }
        }       
    } 
