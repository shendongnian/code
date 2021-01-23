     public class FilterViewModel
        {
            public IEnumerable<string> DataSource { get; set; }       
    
            public FilterViewModel()
            {
                DataSource = new[] { "india", "usa", "uk", "indonesia" };           
            }
        }
    public partial class WinFilter : Window
        {
              public WinFilter()
              {
                 InitializeComponent();
                 FilterViewModel vm = new FilterViewModel();
                 this.DataContext = vm;
              }
              private void Cmb_KeyUp(object sender, KeyEventArgs e)
              {
                  CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Cmb.ItemsSource);
            
                  itemsViewOriginal.Filter = ((o) =>
                  {
                      if (String.IsNullOrEmpty(Cmb.Text)) return true;
                      else
                      {
                         if (((string)o).Contains(Cmb.Text)) return true;
                         else return false;
                      }
                  });
                 itemsViewOriginal.Refresh();
                   
                 // if datasource is a DataView, then apply RowFilter as below and replace above logic with below one
                 /* 
                  DataView view = (DataView) Cmb.ItemsSource; 
                  view.RowFilter = ("Name like '*" + Cmb.Text + "*'"); 
                 */
              }
         }
