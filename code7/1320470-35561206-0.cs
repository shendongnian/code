    <ListBox ItemsSource="{Binding Items}" SelectionMode="Extended">
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <MenuItem Header="GOGO" />
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedItems.Count, RelativeSource={RelativeSource AncestorType={x:Type ListBox}}}" Value="0">
                        <Setter Property="ContextMenu" Value="{x:Null}" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding SelectedItems.Count, RelativeSource={RelativeSource AncestorType={x:Type ListBox}}}" Value="1">
                        <Setter Property="ContextMenu" Value="{x:Null}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding}" HorizontalAlignment="Center" VerticalAlignment="Center" />
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
