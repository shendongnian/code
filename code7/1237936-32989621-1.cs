        public class MyViewModelDesignTime : MyViewModel {
           public MyViewModelDesignTime() : base(new MyModel()){
               //design time ctor. Create design time data here
           }
        }
     and use this class in xaml:
     
         d:DataContext="{d:DesignInstance l:MyViewModelDesignTime, IsDesignTimeCreatable=True}"
