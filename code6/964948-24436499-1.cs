    public void SomeMethod()
    {
         using (MyFirstClass c = new MyFirstClass())
         {
             using (MySecondClass second = new MySecondClass(c))
             {
                 using (MyThirdClass third = new MyThirdClass(c))
                 {
                     //do some stuff
                 }
             }
         }
    }
