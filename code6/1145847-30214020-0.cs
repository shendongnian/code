        public partial class Form1 : Form
        {
            private Dictionary<CheckBox, Func<Model, bool>> _checkboxFilters;
            private IEnumerable<Model> _search;
    
            public Form1()
            {
                InitializeComponent();
    
                _search = new List<Model>
                {
                    new Model {Property1 = 1, Property2 = "aaa"},
                    new Model {Property1 = 2, Property2 = "bbb"},
                    new Model {Property1 = 3, Property2 = "Açık"},
                    new Model {Property1 = 4, Property2 = "Açık"},
                };
    
                _checkboxFilters = new Dictionary<CheckBox, Func<Model, bool>>
                {
                    {checkBox1, new Func<Model,bool>(x => x.Property1.Equals(1))},
                    {checkBox2, new Func<Model,bool>(x => x.Property2.Equals("Açık"))}
                };
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                var checkBoxes = this.Controls.OfType<CheckBox>().ToList();
                var checkedCheckBoxes = checkBoxes.Where(n => n.Checked);
    
                foreach (var checkBox in checkedCheckBoxes)
                {
                    if (_checkboxFilters.ContainsKey(checkBox))
                    {
                        var filter = _checkboxFilters[checkBox];
                        _search = _search.Where(filter);
                    }
                }
            }
        }
    
        class Model
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
        }
