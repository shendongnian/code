    <ScrollViewer Width="200">
        <ItemsControl ItemsSource="{Binding Items}">
            <ItemsControl.ItemTemplate>
                <DataTemplate DataType="local:SelectableObject">
                    <CheckBox IsChecked="{Binding IsSelected}"
                                Command="{Binding DataContext.ItemSelection, RelativeSource={RelativeSource FindAncestor, AncestorType=ItemsControl}}">
                        <CheckBox.Content>
                            <TextBlock Background="Blue" Text="{Binding Name}"/>
                        </CheckBox.Content>
                    </CheckBox>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </ScrollViewer>
