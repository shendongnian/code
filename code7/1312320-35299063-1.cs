    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                // Build list of MyDimensions manually (since I don't have access to your data)
                var obcmMyDim = new ObservableCollection<MyDimension>(CreateData());
                dtgResults.ItemsSource = obcmMyDim;
    
                var names = obcmMyDim.First().obcItemsName; // All entries must have the same list of obcItemsName and in the same order
                for (int i=0; i<names.Count; i++)
                {
                    DataGridTextColumn c = new DataGridTextColumn();
                    c.Header = names[i];
    
                    var b = new Binding();
                    b.Path = new PropertyPath(string.Format("obcItemsMeasured[{0}]", i)); // Binding is based on index into array, thats why all entries have to have the same dynamic fields
                    b.Mode = BindingMode.TwoWay;
    
                    c.Binding = b;
    
                    dtgResults.Columns.Add(c);
                }
    
            }
            public IList<MyDimension> CreateData()
            {
                List<MyDimension> Dimensions = new List<MyDimension>();
                string[] names = new string[] { "PART11", "PART20" }; // They must all have the same obcItemsName/obcItemsMeasured entries, and in the same order
                Dimensions.Add(CreateItem("LOC1-X", names, 0, 0));
                Dimensions.Add(CreateItem("LOC1-Y", names, 0, 0));
                Dimensions.Add(CreateItem("LOC1-D", names, 10.0, 10.1));
                Dimensions.Add(CreateItem("LOC1-RN", names, 0, 0));
                Dimensions.Add(CreateItem("LOC2-X", names, 0, 0));
                Dimensions.Add(CreateItem("LOC2-Y", names, 0, 0));
                Dimensions.Add(CreateItem("LOC1-DF", names, 10.2, 10.3));
                Dimensions.Add(CreateItem("LOC2-TP", names, 0, 0));
                Dimensions.Add(CreateItem("DIST1-M", names, 14.14214, 14.14215));
                Dimensions.Add(CreateItem("DIST2-M", names, 10.4, 10.5));
                // etc...
                return Dimensions;
            }
            public MyDimension CreateItem(string name, string[] names, params double[] values)
            {
                var d = new MyDimension();
                d.NameAxisDimension = name;
                for (int i = 0; i < names.Length; i++)
                {
                    d.obcItemsName.Add(names[i]);
                    d.obcItemsMeasured.Add(values[i]);
                }
                return d;
            }
        }
        public class MyDimension
        {
            public MyDimension()
            {
                obcItemsName = new ObservableCollection<string>();
                obcItemsMeasured = new ObservableCollection<double>();
            }
            public string NameAxisDimension { get; set; }
            public double Nominal { get; set; }
            public double UpperTolerance { get; set; }
            public double LowerTolerance { get; set; }
            public ObservableCollection<string> obcItemsName;
            public ObservableCollection<double> obcItemsMeasured { get; set; } // Has to be a property since it is used in the binding
        }
    }
