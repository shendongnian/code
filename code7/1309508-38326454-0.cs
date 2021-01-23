    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>
        <StackPanel Grid.Column="0" Orientation="Vertical">
            <ListView x:Name="MainList"
                ItemsSource="{x:Bind Organization.People, Mode=OneWay}"
                SelectedIndex="{x:Bind Organization.SelectedIndex, Mode=TwoWay}"
                MinWidth="250" Margin="5">
                <ListView.ItemTemplate>
                    <DataTemplate x:DataType="viewModels:PersonViewModel" >
                        <TextBlock Text="{x:Bind Name, Mode=OneWay}" />
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackPanel>
        <StackPanel Grid.Column="2" Orientation="Vertical">
            <TextBox
                Text="{x:Bind Organization.SelectedPerson.Name, Mode=TwoWay, FallbackValue=''}"
                Margin="5" />
            <TextBox
                Text="{x:Bind Organization.SelectedPerson.Age, Mode=TwoWay, FallbackValue='0'}"
                Margin="5" />
        </StackPanel>
    </Grid> 
