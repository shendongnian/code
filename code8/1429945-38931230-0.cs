    <MenuItem x:Name="MyToggleMenu"  Header="My Toggle Menu" >
        <MenuItem.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedItem.ToggleMenuVisible}" Value="False">
                        <Setter Property="UIElement.Visibility" Value="Collapsed" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding SelectedItem.ToggleMenuVisible}" Value="True">
                        <Setter Property="UIElement.Visibility" Value="Visible" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </MenuItem.Style>
    </MenuItem>
