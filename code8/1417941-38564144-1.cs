    <ListView ItemsSource="{Binding Components}">
                <ListView.Resources>
                    <DataTemplate DataType="{x:Type ConcreteAttribute1}">
                        <TextBlock Text="Con1"></TextBlock>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type ConcreteAttribute2}">
                        <TextBlock Text="Con2"></TextBlock>
                    </DataTemplate>
                </ListView.Resources>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ContentControl Content="{Binding Foo}"></ContentControl>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
