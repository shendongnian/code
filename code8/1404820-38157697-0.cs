    namespace WpfBinding.Interface
    {
        /// <summary>
        /// Interaction logic for WinGrd.xaml
        /// </summary>
        public partial class WinGrd : Window
        {
            public IEnumerable<IGridlyViewModel> GridlyItemsSource { get { return new[] { new ModelData() }; } } 
    
            public WinGrd()
            {
                InitializeComponent();
    
                this.DataContext = this;
            }
    
            #region FilteringInterface
            
            public static Type GetFilteringInterface(DependencyObject obj)
            {
                return (Type)obj.GetValue(FilteringInterfaceProperty);
            }
    
            public static void SetFilteringInterface(DependencyObject obj, Type value)
            {
                obj.SetValue(FilteringInterfaceProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for FilteringInterface.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty FilteringInterfaceProperty =
                DependencyProperty.RegisterAttached("FilteringInterface", typeof(Type), typeof(WinGrd), 
                            new PropertyMetadata(new PropertyChangedCallback(FilteringInterfaceChanged)));
    
            private static void FilteringInterfaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DataGrid dGrid = (DataGrid)d;
                dGrid.AutoGeneratingColumn += dGrid_AutoGeneratingColumn;
            }               
    
            #endregion
    
            #region ViewModel AttachedProperty
    
            public static Type GetViewModel(DependencyObject obj)
            {
                return (Type)obj.GetValue(ViewModelProperty);
            }
    
            public static void SetViewModel(DependencyObject obj, Type value)
            {
                obj.SetValue(ViewModelProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ViewModelProperty =
                DependencyProperty.RegisterAttached("ViewModel", typeof(Type), typeof(WinGrd), new PropertyMetadata(null));                
    
            #endregion
    
            static void dGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                DataGrid dGrid = (DataGrid)sender;
                
                TypeInfo viewModelTypeInfo = WinGrd.GetViewModel(dGrid).GetTypeInfo();
                Type[] allInterfaces = viewModelTypeInfo.GetInterfaces();
    
                Type foundInterface = allInterfaces.FirstOrDefault((tp) => { return tp == WinGrd.GetFilteringInterface(dGrid); });
    
                if (foundInterface == null)
                    return;
    
                TypeInfo foundInterfaceTypeInfo = foundInterface.GetTypeInfo();
                PropertyInfo[] foundInterfaceProps = foundInterfaceTypeInfo.GetProperties();
                
                if (foundInterfaceProps.FirstOrDefault((p) => { return p.Name == e.PropertyName; }) != null)
                    System.Diagnostics.Debug.WriteLine(e.PropertyName + " found and used for Column !");
                else
                    e.Cancel = true;
            }
     
        }
    
        #region Classes
    
        public interface IGridlyViewModel
        {
            int CanBeSeen { get; }
        }
    
        public class ModelData : IGridlyViewModel
        {
            #region IGridlyViewModel
            public int CanBeSeen { get { return 42; } }
            #endregion
            public int Other { get { return 9001; } }
        }
    
        #endregion
    }
