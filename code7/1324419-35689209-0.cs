    <MenuItem Header="Time Ranges" x:Name="TimeRangesMenuItem">
        <MenuItem.Resources>
            <CollectionViewSource Source="{Binding ElementName=TimeRangesMenuItem, Path=TimeSpans}" x:Key="TimeSpanMenuItems" />
        </MenuItem.Resources>
        <MenuItem.ItemsSource>
            <CompositeCollection>
                <CollectionContainer Collection="{Binding Source={StaticResource TimeSpanMenuItems}}" />
                <Separator />
                <MenuItem Header="Add New" cal:Message.Attach="NewTimeSpan()" />
            </CompositeCollection>
        </MenuItem.ItemsSource>
        <MenuItem.ItemTemplate>
            <ItemContainerTemplate>
                <MenuItem Header="{Binding Name}" cal:Message.Attach="ConfigureTimeSpan()" />
            </ItemContainerTemplate>
        </MenuItem.ItemTemplate>
    </MenuItem>
