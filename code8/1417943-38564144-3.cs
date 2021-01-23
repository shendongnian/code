    <ListView ItemsSource="{Binding Components}">
        <ListView.Resources>
            <DataTemplate DataType="{x:Type ConcreteAttribute1}">
                <StackPanel>
                    <TextBlock Text="{Binding Name, Mode=OneWay}"/>
                    <TextBox Text="{Binding Number, Mode=OneWay}"></TextBox>
                </StackPanel>
            </DataTemplate>
            <DataTemplate DataType="{x:Type ConcreteAttribute2}">
                <StackPanel>
                    <TextBlock Text="{Binding Name, Mode=OneWay}"/>
                    <CheckBox IsChecked="{Binding B, Mode=OneWay}"></CheckBox>
                </StackPanel>
            </DataTemplate>
        </ListView.Resources>
        <ListView.ItemTemplate>
            <DataTemplate>
                <ContentControl Content="{Binding Foo}" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
