    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    
    namespace XXX
    {
        public class CornerBorderCenterModel
        {
            public int Corners { get; set; }
            public int Borders { get; set; }
            public int Centers { get; set; }
        }
        public class SkuReference : INotifyPropertyChanged
        {
            static JavaScriptSerializer json = new JavaScriptSerializer();
    
            private static string[] _jsonStringParts =
                new[] { nameof(Borders), nameof(Corners), nameof(Centers) };
    
            public SkuReference()
            {
                PropertyChanged += OnPropertyChanged;
            }
    
            public int Corners
            {
                get { return _Corners; }
                set
                {
                    if (_Corners != value)
                    {
                        _Corners = value;
                        RaisePropertyChanged();
                    }
                }
            }
            private int _Corners;
    
            public int Borders
            {
                get { return _Borders; }
                set
                {
                    if (_Borders != value)
                    {
                        _Borders = value;
                        RaisePropertyChanged();
                    }
                }
            }
            private int _Borders;
    
            public int Centers
            {
                get { return _Centers; }
                set
                {
                    if (_Centers != value)
                    {
                        _Centers = value;
                        RaisePropertyChanged();
                    }
                }
            }
            private int _Centers;
    
            private void UpdateCBCFromQuantity()
            {
                //if Quantity is a CBC and is not null do the following:
    
                var cbc = json.Deserialize<CornerBorderCenterModel>(_Quantity.ToString());
    
                if (cbc != null)
                {
                    Corners = cbc.Corners;
                    Borders = cbc.Borders;
                    Centers = cbc.Centers;
                }
            }
    
            public string Quantity
            {
                get { return _Quantity; }
                set
                {
                    if (_Quantity != value)
                    {
                        _Quantity = value;
                        RaisePropertyChanged();
                    }
                }
            }
            private string _Quantity;
    
            private void UpdateJsonStringFromCBC()
            {
                Quantity = string.Format(
                    "{{ 'Corners': {0}, 'Borders': {1}, 'Centers': {2} }}",
                    _Corners,
                    _Borders,
                    _Centers);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
    
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (_jsonStringParts.Contains(e.PropertyName))
                    UpdateJsonStringFromCBC();
    
                else if (e.PropertyName == nameof(Quantity))
                    UpdateCBCFromQuantity();
            }
        }
    }
    <StackPanel Orientation="Horizontal" DataContext="{Binding UpsertSkuReference}">
      <TextBox Text="{Binding Corners}" IsEnabled="{Binding CBCIsChecked}" />
      <TextBox Text="{Binding Borders}" IsEnabled="{Binding CBCIsChecked}" />
      <TextBox Text="{Binding Centers}" IsEnabled="{Binding CBCIsChecked}" />
    </StackPanel>
