    public ApplicationViewModel()
    {
        //shared model
        var model = new MyModel();
        //Add pages
        BasePageViewModels.Add("Home Page", new HomeViewModel(model));
        BasePageViewModels.Add("Summary Page", new SummaryViewModel(model));
        BasePageViewModels.Add("AddTestRun Page", new AddTestRunViewModel(model));
        //some code here
        CurrentBasePageViewModel = BasePageViewModels["Home Page"];
    }
    <UserControl x:Class="ApplicationView"
                 xmlns:vm="clr-namespace:MyApp.ViewModels"
                 xmlns:vw="clr-namespace:MyApp.Views">
    
        <UserControl.Resources>
    
            <DataTemplate DataType="{x:Type vm:HomeViewModel}">
                <vw:HomeView />
            </DataTemplate>
    
            <DataTemplate DataType="{x:Type vm:SummaryViewModel}">
                <vw:SummaryView />
            </DataTemplate>
    
            <DataTemplate DataType="{x:Type vm:AddTestRunViewModel}">
                <vw:AddTestRunView />
            </DataTemplate>
    
        </UserControl.Resources>
    
        <ContentControl Content={Binding CurrentBasePageViewModel} />
    
    </UserControl>
