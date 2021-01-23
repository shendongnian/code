    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var staff = new List<DynamicPerson>();
            var person1 = new DynamicPerson();
            var feature1 = new DynamicPerson.ColumnsValues
            {
                ColumnName = "FirstName",
                IdProperty = 1,
                TypeOfColumn = TypeCode.String,
                ValueOfColumn = "Albert"
            };
            person1.Features.Add(feature1);
            var feature2 = new DynamicPerson.ColumnsValues
            {
                ColumnName = "LastName",
                IdProperty = 1,
                TypeOfColumn = TypeCode.String,
                ValueOfColumn = "Dunno"
            };
            person1.Features.Add(feature2);
            var feature3 = new DynamicPerson.ColumnsValues
            {
                ColumnName = "Alive",
                IdProperty = 1,
                TypeOfColumn = TypeCode.Boolean,
                ValueOfColumn = "True"
            };
            person1.Features.Add(feature3);
            staff.Add(person1);
            staff.Add(person1);
            DataContext = staff;
        }
    }
