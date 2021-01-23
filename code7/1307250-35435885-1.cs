    <UserControl.Resources>
        <Style TargetType="TextBox">
            <Setter Property="IsReadOnly" Value="False"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding CanUserEdit}" Value="false">
                    <Setter Property="IsReadOnly" Value="True"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
        <Style TargetType="ComboBox">
            <Setter Property="IsEnabled" Value="True"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding CanUserEdit}" Value="false">
                    <Setter Property="IsEnabled" Value="False"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </UserControl.Resources>
