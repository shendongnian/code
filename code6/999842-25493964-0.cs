    MainView.xaml.cs
    
    public void MainView()
    {
         SubViewModel subVm = new SubViewModel();
         
         //If you are instantiating your views
         MySubView view1 = new MySubView(subVm);
         MySecondSubView view2 = new MySecondSubView(view2);
    
         //Otherwise
         view1.DataContext = subVm;
         view2.DataContext = subVm;
    }
