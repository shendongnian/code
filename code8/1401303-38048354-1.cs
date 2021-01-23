    public class MainViewModelFactory{
    
    private static MainViewModel main{get;set;}
    public static MainViewModel GetReference(){
    if(main == null){
    main = new MainViewModel();
    return main;
    }else 
       return main;
    }
    }
