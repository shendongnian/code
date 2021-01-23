    <Window.Resources>
        <ObjectDataProvider  ObjectInstance="{x:Type Colors}" MethodName="GetProperties" x:Key="colorPropertiesOdp" />
        <CollectionViewSource x:Key="FilterCollectionView" Filter="CollectionViewSource_Filter" Source="{StaticResource colorPropertiesOdp}" />
    </Window.Resources>
    <ComboBox ItemsSource="{Binding Source={StaticResource FilterCollectionView}}" DisplayMemberPath="Name"  SelectedValuePath="Name"/>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            System.Reflection.PropertyInfo pi = (System.Reflection.PropertyInfo)e.Item;
            if (pi.Name == "Transparent")
            {
                e.Accepted = false;
            }
            else
            {
                e.Accepted = true;
            }
        }
    }
