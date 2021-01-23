    public static void UseMyDal(Action<MyDal> actions){
       using(var dal = new MyDal())
       {
          actions(dal);
       }
    }
