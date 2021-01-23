    <Menu>
        <MenuItem Header="Choose item" ItemsSource="{Binding enumData}" DisplayMemberPath="Enum">
            <MenuItem.ItemContainerStyle>
                <Style TargetType="MenuItem">
                    <Setter Property="IsCheckable" Value="True"/>
                    <Setter Property="IsChecked" Value="{Binding IsChecked, Mode=TwoWay}"/>
                    <Setter Property="StaysOpenOnClick" Value="True"/>
                </Style>
            </MenuItem.ItemContainerStyle>
        </MenuItem>
    </Menu>
