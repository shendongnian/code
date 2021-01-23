    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Kind = new Collection<Reason>();
            Kind.Add(new Reason("First", 0));
            Kind.Add(new Reason("Second", 1));
            Column1.DataSource = Kind;
            Column1.DisplayMember = "Name";
                
            // Do not set value member to get the actual selected object
            // If you explicitly set it, you'll get you property value
            // Column1.ValueMember = "value" 
            dataGridView.EditingControlShowing += (sender, args) =>
                {
                    var cmb = args.Control as ComboBox;
                    if (cmb == null)
                        return;
                    cmb.SelectedIndexChanged += (o, eventArgs) =>
                        System.Diagnostics.Debug.Write(cmb.SelectedItem.ToString());
                };
        }
    
        public Collection<Reason> Kind { get; set; }
    }
