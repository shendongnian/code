    <ItemsControl ...>
        ...
        <ItemsControl.Resources>
            <Style TargetType="ToggleButton">
                <Style.Triggers>
                    <Trigger Property="IsChecked" Value="True">
                        <Setter Property="Background" Value="Green" />
                    </Trigger>
                </Style.Triggers>
            </Style>                
        </ItemsControl.Resources>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ToggleButton Content="{Binding}">
                    <ToggleButton.Template>
                        <ControlTemplate>
                            <Label Content="{Binding}" Background="{TemplateBinding Background}" />
                        </ControlTemplate>
                    </ToggleButton.Template>
                </ToggleButton>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
