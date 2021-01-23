    <ItemsControl>
        <ItemsControl.Resources>
            <CollectionViewSource x:Key="AnimalCollection" Source="{Binding Animals}"/>
        </ItemsControl.Resources>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel IsItemsHost="True" Orientation="Horizontal" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border Margin="5">
                    <Image Source="{Binding ImageUrl}" />
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemsSource>
            <CompositeCollection>
                <CollectionContainer Collection="{Binding Source={StaticResource AnimalCollection}}"/>
                <Border Margin="5">
                    <Button Command="{Binding AddAnimal}">
                        <Image Source="YourAddButtonSource"/>
                    </Button>
                </Border>
            </CompositeCollection>
        </ItemsControl.ItemsSource>
    </ItemsControl>
