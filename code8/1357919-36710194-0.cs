    <Grid xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Mobile.Controls.GridView">
    </Grid>
    public partial class GridView : Grid
    {
        public GridView()
        {
            InitializeComponent();
            for (var i = 0; i < MaxColumns; i++)
                ColumnDefinitions.Add(new ColumnDefinition());
        }
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<GridView, object>(p => p.CommandParameter, null);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<GridView, ICommand>(p => p.Command, null);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<GridView, IEnumerable<object>>(p => p.ItemsSource, null, BindingMode.OneWay, null, (bindable, oldValue, newValue) =>  { ((GridView)bindable).BuildTiles(newValue); });
        private int _maxColumns = 2;
        private float _tileHeight = 0;
        public Type ItemTemplate { get; set; } = typeof(DocumentTypeTemplate);
        public int MaxColumns
        {
            get { return _maxColumns; }
            set { _maxColumns = value; }
        }
        public float TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value);  }
        }
        public void BuildTiles(IEnumerable<object> tiles)
        {
            try
            {
                if (tiles == null || tiles.Count() == 0)
                    Children?.Clear();
                // Wipe out the previous row definitions if they're there.
                RowDefinitions?.Clear();
                var enumerable = tiles as IList ?? tiles.ToList();
                var numberOfRows = Math.Ceiling(enumerable.Count / (float)MaxColumns);
                for (var i = 0; i < numberOfRows; i++)
                    RowDefinitions?.Add(new RowDefinition { Height = TileHeight });
                for (var index = 0; index < enumerable.Count; index++)
                {
                    var column = index % MaxColumns;
                    var row = (int)Math.Floor(index / (float)MaxColumns);
                    var tile = BuildTile(enumerable[index]);
                    Children?.Add(tile, column, row);
                }
            }
            catch { // can throw exceptions if binding upon disposal
            }
        }
        private Layout BuildTile(object item1)
        {
            var buildTile = (Layout)Activator.CreateInstance(ItemTemplate, item1);
            buildTile.InputTransparent = false;
            var tapGestureRecognizer = new TapGestureRecognizer
            {
                Command = Command,
                CommandParameter = item1,
                NumberOfTapsRequired = 1                
            };
            buildTile?.GestureRecognizers.Add(tapGestureRecognizer);
            return buildTile;
        }
    }
