    public IMyInterface {
      void MyMethod2();
    }
    public class AccountBL<T> where T : BaseAccounbt, new(), IMyInterface {
      // Members can access T.MyMethod2()
    }
