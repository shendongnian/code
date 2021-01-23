    <ItemsControl>
        <ItemsControl.Resources>
            <CollectionViewSource x:Key="viewSource" Source="{Binding Path=Persons}" IsLiveGroupingRequested="True">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="PersonType" />
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
            <DataTemplate DataType="{x:Type myNamespace:Person}"> ... </DataTemplate>
            <DataTemplate DataType="{x:Type myNamespace:Employee}"> ... </DataTemplate>
            <DataTemplate DataType="{x:Type myNamespace:Customer}"> ... </DataTemplate>
        </ItemsControl.Resources>
        <ItemsControl.ItemsSource>
            <Binding Source="{StaticResource viewSource}" />
        </ItemsControl.ItemsSource>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Margin" Value="5" />
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.GroupStyle>
            <GroupStyle>
                <GroupStyle.HeaderTemplate>
                    <DataTemplate>
                        <TextBlock FontSize="20" Text="{Binding Name}" />
                    </DataTemplate>
                </GroupStyle.HeaderTemplate>
            </GroupStyle>
        </ItemsControl.GroupStyle>
    </ItemsControl>
