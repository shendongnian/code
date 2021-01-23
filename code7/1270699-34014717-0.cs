    <ScrollViewer>
        <ItemsControl ItemsSource="{Binding Items}">
            <ItemsControl.ItemTemplate>
                <DataTemplate DataType="local:SelectableObject">
                    <CheckBox IsChecked="{Binding IsSelected}"
                                Content="{Binding Name}"
                                Command="{Binding DataContext.ItemSelection, RelativeSource={RelativeSource FindAncestor, AncestorType=ItemsControl}}"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </ScrollViewer>
