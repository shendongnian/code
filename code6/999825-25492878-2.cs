    public abstract class PurchaseSystemControllerBase : IInitializable {
        protected PurchaseSystemViewModelBase ViewModel { get; private set; }
    }
    public abstract class PurchaseSystemControllerBase<TViewModel>
                        : PurchaseSystemControllerBase
        where TViewModel : PurchaseSystemViewModelBase {
        // note: property implementations should prevent this and base.ViewModel
        // from getting out of sync
        protected new TViewModel ViewModel { get; private set; }
    }
    
    public abstract class PurchaseSystemViewModelBase : ViewModelBase {
        protected PurchaseSystemControllerBase Controller { get; private set; }
    }
    public abstract class PurchaseSystemViewModelBase<TController>
                        : PurchaseSystemViewModelBase
        where TController : PurchaseSystemControllerBase {
        // note: property implementations should prevent this and base.Controller
        // from getting out of sync
        protected new TController Controller { get; private set; }
    }
    
    
    public sealed class PurchaseSystemController
                      : PurchaseSystemControllerBase<PurchaseSystemViewModel> {
    }
    public sealed class PurchaseSystemViewModel
                      : PurchaseSystemViewModelBase<PurchaseSystemController> {
    }
