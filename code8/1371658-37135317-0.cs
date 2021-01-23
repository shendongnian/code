        public partial class Combiner : Window
    {
        public Combiner()
        {
            InitializeComponent();
            CreateDataGridColumns();
        }
        private void CreateDataGridColumns()
        {
            var gridView = new GridView();
            PlanningDataGrid.View = gridView;
            gridView.Columns.Add(new GridViewColumn() { Header = "Тип мероприятия", DisplayMemberBinding = new Binding("Key") }); // Создаем первый столбец
            var eventTypeList = GetEventTypesList();
            foreach (string eventType in eventTypeList)
            {
                Binding binding = new Binding();
                var listViewColumn = new GridViewColumn
                {
                    Header = eventType,
                    Width = 30,
                    CellTemplate = GenerateCellTemplate(eventType),
                };
                gridView.Columns.Add(listViewColumn);
            }
        }
        private DataTemplate GenerateCellTemplate(string eventType)
        {
            FrameworkElementFactory checkbox = new FrameworkElementFactory(typeof(CheckBox));
            checkbox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("Value[" + eventType + "]") {Mode = BindingMode.TwoWay});
            return new DataTemplate() {VisualTree = checkbox};
        }
        /// <summary>
        /// Собирает список типов мероприятий из БД
        /// </summary>
        /// <returns></returns>
        private List<string> GetEventTypesList()
        {
            using (var db = new IP_dbEntities())
            {
                return db.EVENTS_TYPE.Select(e => e.event_type.Trim()).ToList();
            }
        }
    }
