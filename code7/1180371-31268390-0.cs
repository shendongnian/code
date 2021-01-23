      <StackPanel>
        <RadioButton Name="x1"/>
        <RadioButton Name="x2"/>
        <RadioButton Name="x3"/>
        <RadioButton Name="x4"/>
        <Button Content="Click">
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="IsEnabled" Value="False"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=x1, Path=IsChecked}" Value="True">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding ElementName=x2, Path=IsChecked}" Value="True">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding ElementName=x3, Path=IsChecked}" Value="True">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding ElementName=x4, Path=IsChecked}" Value="True">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
    </StackPanel>
