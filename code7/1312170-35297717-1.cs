    using System.Windows;
    using System.Data;
    
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                // Build list of MyDimensions manually (since I don't have access to your data)
                var Dimensions = CreateData();
                this.DataContext = new MyViewModel(Dimensions);
            }
            public IList<MyDimension> CreateData()
            {
                List<MyDimension> Dimensions = new List<MyDimension>();
                MyDimension d;
                Dimensions.Add(new MyDimension() { NameAxisDimension = "LOC1-X" });
                Dimensions.Add(new MyDimension() { NameAxisDimension = "LOC1-Y" });
                d = new MyDimension() { NameAxisDimension = "LOC1-D" };
                d.obcItemsName.Add("PART11");
                d.obcItemsMeasured.Add(10.0);
                d.obcItemsName.Add("PART20");
                d.obcItemsMeasured.Add(10.1);
                Dimensions.Add(d);
                Dimensions.Add(new MyDimension() { NameAxisDimension = "LOC1-RN" });
                Dimensions.Add(new MyDimension() { NameAxisDimension = "LOC2-X" });
                Dimensions.Add(new MyDimension() { NameAxisDimension = "LOC2-Y" });
                d = new MyDimension() { NameAxisDimension = "LOC2-DF" };
                d.obcItemsName.Add("PART11");
                d.obcItemsMeasured.Add(10.2);
                d.obcItemsName.Add("PART20");
                d.obcItemsMeasured.Add(10.3);
                Dimensions.Add(d);
                Dimensions.Add(new MyDimension() { NameAxisDimension = "LOC2-TP" });
                d = new MyDimension() { NameAxisDimension = "DIST1-M" };
                d.obcItemsName.Add("PART11");
                d.obcItemsMeasured.Add(14.14214);
                d.obcItemsName.Add("PART20");
                d.obcItemsMeasured.Add(14.14215);
                Dimensions.Add(d);
                d = new MyDimension() { NameAxisDimension = "DIST2-M" };
                d.obcItemsName.Add("PART11");
                d.obcItemsMeasured.Add(10.4);
                d.obcItemsName.Add("PART20");
                d.obcItemsMeasured.Add(10.5);
                Dimensions.Add(d);
    
                d = new MyDimension() { NameAxisDimension = "Other Field" };
                d.obcItemsName.Add("PartyLikeIts");
                d.obcItemsMeasured.Add(1999);
                Dimensions.Add(d);
                // etc...
                return Dimensions;
            }
        }
    
        public class MyViewModel
        {
            public DataTable MyDataTable { get; set; }
    
            public MyViewModel(IList<MyDimension> Dimensions)
            {
                // Create a DataTable
                // Add the already known columns - static
                // Add the unknown at designtime columns - dynamic
                // Optionally hook the RowChanged event of the DataTable to push the changes back to Dimensions
    
                MyDataTable = new DataTable();
                // Add the 'static' columns
                MyDataTable.Columns.Add("NameAxisDimension", typeof(string)).ReadOnly = true; // Assuming this is the PK and shouldn't change
                MyDataTable.Columns.Add("Nominal", typeof(double));
                MyDataTable.Columns.Add("UpperTolerance", typeof(double));
                MyDataTable.Columns.Add("LowerTolerance", typeof(double));
                // Add the 'dynamic' columns
                var names = Dimensions.SelectMany(aa => aa.obcItemsName.Select(bb => bb)).Distinct(); // Get a list of the distinct values in all of the obcItemsName collections
                foreach (var name in names)
                    MyDataTable.Columns.Add(name, typeof(double));
                foreach (var dim in Dimensions)
                {
                    List<object> vals = new List<object> { dim.NameAxisDimension, dim.Nominal, dim.UpperTolerance, dim.LowerTolerance }; // static field values
                    foreach (var name in names)
                    {
                        object val = 0.0; // Default value if obcItemsName doesn't have this dynamic field - could also use DBNull.Value
                        int idx = dim.obcItemsName.IndexOf(name);
                        if (idx != -1)
                            val = dim.obcItemsMeasured[idx];
                        vals.Add(val);
                    }
                    MyDataTable.Rows.Add(vals.ToArray());
                }
    
                // If needed, hook the RowChanged event to capture changes and push the changes back to the original collection
                MyDataTable.RowChanged += (s, e) =>
                {
                    if (e.Action == DataRowAction.Change)
                    {
                        // Assumes that "NameAxisDimension" is the PK (and unique to the row)
                        var nameAxisDimension = e.Row.Field<string>("NameAxisDimension");
                        var item = Dimensions.FirstOrDefault(aa => aa.NameAxisDimension == nameAxisDimension);
                        if (item != null)
                        {
                            // Found the entry, update its values
                            // Static fields
                            item.Nominal = e.Row.Field<double>("Nominal");
                            item.UpperTolerance = e.Row.Field<double>("UpperTolerance");
                            item.LowerTolerance = e.Row.Field<double>("LowerTolerance");
                            // Dynamic fields
                            foreach (var name in names)
                            {
                                int idx = item.obcItemsName.IndexOf(name);
                                if (idx != -1)
                                {
                                    item.obcItemsMeasured[idx] = e.Row.Field<double>(name);
                                }
                                else
                                {
                                    // This row doesn't have that name in obcItemsName. Add it?
                                    item.obcItemsName.Add(name);
                                    item.obcItemsMeasured.Add(e.Row.Field<double>(name));
                                }
                            }
                        }
                    }
                };
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
            public ObservableCollection<double> obcItemsMeasured;
        }
    }
