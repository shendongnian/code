    public partial class MainWindow: Window
    {
        ...
        var vm = new BaseViewModel();
        this.Datacontext = vm;
        vm.ClosingRequest += (sender, e) => this.Close();
    }
