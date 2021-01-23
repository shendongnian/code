    public partial class Win32599087 : Window
        {
            public ObservableCollection<Signal> tempSigList { get; set; }
            public ObservableCollection<RawVal> tempRawVal { get; set; }
    
            public Win32599087()
            {
                InitializeComponent();
    
                tempRawVal = new ObservableCollection<RawVal>() { 
                    new RawVal(){ Name="RawName1", Value=1},
                    new RawVal(){ Name="RawName2", Value=2},
                    new RawVal(){ Name="RawName3", Value=3},
                    new RawVal(){ Name="RawName4", Value=4}
                    
                };
    
                tempSigList = new ObservableCollection<Signal>() {             
                    new Signal(){Name="signal1", Value = 1, RawValues = tempRawVal}
                };
    
                SignalGrid.DataContext = tempSigList;
            }
        }
//////////////
        <DataGrid x:Name="SignalGrid" AutoGenerateColumns="False" SelectedIndex="0" ItemsSource="{Binding}">
            <DataGrid.Columns>                
              <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
              <DataGridTextColumn Header="Value" Binding="{Binding Value}"/>
              <DataGridComboBoxColumn Header="RawValues">
                <DataGridComboBoxColumn.EditingElementStyle>
                    <Style TargetType="ComboBox">
                        <Setter Property="ItemsSource" Value="{Binding Path=RawValues}" />
                        <Setter Property="DisplayMemberPath" Value="Name" />
                        <Setter Property="SelectedValuePath" Value="Value" />
                    </Style>
                  </DataGridComboBoxColumn.EditingElementStyle>
              </DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
