    public partial class ExampleWindow : Window
    {
        public ExampleWindow()
        {
            // In the constructor this should always work!
            InitializeComponent();
            var predValues = new List<ComplexItemClass>();
            predValues.Add(new ComplexItemClass("Alpha","A"));
            predValues.Add(new ComplexItemClass("Beta","B"));
            predValues.Add(new ComplexItemClass("Gamma","G"));
            
            this.comboPredict.ItemsSource = predValues;
            this.comboPredict.SelectedIndex = 0;
        }
        public class ComplexItemClass
        {
            public ComplexItemClass(string dname, string iname)
            {
                this.DisplayName = dname;
                this.InternalName = iname;                     
            }
            public string DisplayName { get; set; }
            public string InternalName { get; set; }
            }
        }
    }
