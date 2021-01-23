csharp
<UserControl.Resources>
    <Style TargetType="TabItem">
        <Setter Property="Header" Value="{Binding DataContext.Name}" />
    </Style>
</UserControl.Resources>
What i did instead was:
1 - Create a Tab Control with a prism region (Inside MainWindows in my case).
xaml
<TabControl prism:RegionManager.RegionName="TabRegion"/>
2 - Create a "user control" of type TabItem (NewTabView) that holds the tab views. Note that i'm binding the Header here. The idea here would be to add a region here as well inside the grid (for the content of the tab), or to make every control that needs to be inside the tab a child of TabItem.
xaml
<TabItem 
    x:Class="Client.WPF.Views.NewTab"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:prism="http://prismlibrary.com/"             
    prism:ViewModelLocator.AutoWireViewModel="True"
    Header="{Binding Title}">
    <Grid>
        <Button Content="{Binding RandomNumber}"/>
    </Grid>
</TabItem>
csharp
///The code behind should inherit from TabItem as well
public partial class NewTab : TabItem
csharp
///The viewmodel has a "Title" property
        private string _title = "New Tab";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
4 - Finally, i navigate to the NewTab like this (MainWindowViewModel code)
csharp
        public DelegateCommand NewTab { get; }
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregato)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            
            NewTab = new DelegateCommand(NewTabAction);
        }
        private void NewTabAction()
        {
            regionManager.RequestNavigate("TabRegion", "NewTab");
        }
5 - As an added bonus, if you want to allow more than 1 instance of the tab, you can do something like this on the view model (NewTabViewModel).
csharp
///First add the IConfirmNavigationRequest interface
public class NewTabViewModel : BindableBase, IConfirmNavigationRequest
///...
///Then the implementation should look like this
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);///Will allow multiple instances (tabs) of this view
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
Or you could also add views directly to the region. Although you would need to resolve views using the IContainerProvider. Something like this:
csharp
var view = containerProvider.Resolve<NewTab>();
regionManager.Regions["TabRegion"].Add(view);
