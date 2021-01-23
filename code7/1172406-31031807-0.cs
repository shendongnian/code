    <Window.Resources>
        <ResourceDictionary>
            <local:GeneralDataGridViewModel x:Key="generalDataGridVm"/>
        </ResourceDictionary>
    </Window.Resources>
    <StackPanel Orientation="Vertical">
        <DataGrid DataContext="{StaticResource generalDataGridVm}" Name="DataGrid1" ItemsSource="{Binding Collection}">
            <DataGrid.Columns>
                <DataGridComboBoxColumn x:Name="chbCodes"
                             Header="Code"                  
                             ItemsSource="{Binding Path=DataContext.Collection, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" />
            </DataGrid.Columns>
        </DataGrid>
    </StackPanel>
