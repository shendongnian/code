    public static T UseMyDal<T>(Func<MyDal,T> actions){
       using(var dal = new MyDal())
       {
          return actions(dal);
       }
    }
