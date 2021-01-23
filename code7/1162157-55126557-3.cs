    using Products.MVVMLibrary;
    using Products.MVVMLibrary.Interfaces;
    using MyNameSpace.Views;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace MyNameSpace.ViewModel
    {
    public class ApplicationVM : ObservableObject
    {
        private MyNameSpace IControlItem currentNavigationItem;
        private MyNameSpace ContentControl currentView;
        private MyNameSpace List<IControlItem> NavigationList;
        private MyNameSpace ICommand changeViewCommand;
        private MyNameSpace ViewConverter viewDictionary;
        private MyNameSpace Dictionary<string, LinkViewToViewModel> View_ViewModel;
        public ApplicationVM()
        {
            viewDictionary = new ViewConverter();
            View_ViewModel = new Dictionary<string, LinkViewToViewModel>();
            NavigationList = new List<IControlItem>();
            InitialiseLists();
        }
        private MyNameSpace void AddControlNavigationItems(string name, ContentControl view, ObservableObject viewModel)
        {
            View_ViewModel.Add(name, new LinkViewToViewModel(view, viewModel));
            IControlItem item = (IControlItem)viewModel;
            NavigationList.Add(item);
        }
        private MyNameSpace void InitialiseLists()
        {
            AddControlNavigationItems("Sales", new SalesForm(), new SalesEntryVM());
            AddControlNavigationItems("Purchases", new PurchaseEntryForm(), new PurchasesVM());
            AddControlNavigationItems("Setup", new SetupForm(), new SetupFormVM());
            //Use the property instead which creates the instance and triggers property change
            CurrentViewModel = (IControlItem)View_ViewModel[View_ViewModel.Keys.ElementAt(0)].ViewModel;
            CurrentView = View_ViewModel[View_ViewModel.Keys.ElementAt(0)].View;
        }
        public List<IControlItem> ControlItemsNamesList
        {
            get => NavigationList;
        }
        /// <summary>
        /// Provides a list of names for Navigation controls to the control item
        /// </summary>
        public Dictionary<string, LinkViewToViewModel> ApplicationViews
        {
            get
            {
                return View_ViewModel;
            }
            set
            {
                View_ViewModel = value;
            }
        }
        public ContentControl CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
        public IControlItem CurrentViewModel
        {
            get
            {
                return currentNavigationItem;
            }
            set
            {
                if (currentNavigationItem != value)
                {
                    currentNavigationItem = value;
                    OnPropertyChanged("CurrentViewModel");
                }
            }
        }
        /// <summary>
        /// This property is bound to Button Command in XAML.
        /// Calls ChangeViewModel which sets the CurrentViewModel
        /// </summary>
        public ICommand ChangeViewCommand
        {
            get
            {
                if (changeViewCommand == null)
                {
                    changeViewCommand = new ButtonClick(
                        p => ViewChange((IControlItem)p), CanExecute);
                }
                return changeViewCommand;
            }
        }
        #region Methods
        private MyNameSpace void ViewChange(IControlItem viewname)
        {
            foreach (KeyValuePair<string, LinkViewToViewModel> item in View_ViewModel)
            {
                if (item.Key == viewname.ControlName)
                {//Set the properties of View and ViewModel so they fire PropertyChange event
                    CurrentViewModel = (IControlItem)item.Value.ViewModel;
                    CurrentView = item.Value.View;
                    break;
                }
            }
        }
        private MyNameSpace bool CanExecute()
        {
            return true;
        }
        #endregion
      }
    }
