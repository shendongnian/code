    public abstract class PurchaseSystemControllerBase : IInitializable {
        protected PurchaseSystemViewModelBase ViewModel { get; private set; }
    }
    public abstract class PurchaseSystemControllerBase<TViewModel> : PurchaseSystemControllerBase
        where TViewModel : PurchaseSystemViewModelBase {
        protected new TViewModel ViewModel { get; private set; }
    }
    
    public abstract class PurchaseSystemViewModelBase : ViewModelBase {
        protected PurchaseSystemControllerBase Controller { get; private set; }
    }
    public abstract class PurchaseSystemViewModelBase<TController> : PurchaseSystemViewModelBase
        where TController : PurchaseSystemControllerBase {
        protected new TController Controller { get; private set; }
    }
    
    
    public sealed class PurchaseSystemController : PurchaseSystemControllerBase<PurchaseSystemViewModel> {
    }
    public sealed class PurchaseSystemViewModel : PurchaseSystemViewModelBase<PurchaseSystemController> {
    }
