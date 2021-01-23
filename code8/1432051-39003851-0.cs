    <Style x:Key="TogglebuttonStyle" TargetType="ToggleButton" BasedOn="{StaticResource {x:Type ToggleButton}}">
        <Style.Triggers>
            <Trigger Property="IsChecked" Value="True">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <Image Source="{StaticResource ImagePlus}" />
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Trigger>
            <Trigger Property="IsChecked" Value="False">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <Image Source="{StaticResource ImageMinus}" />
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Trigger>
            <Trigger Property="IsChecked" Value="{x:Null}">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <Image Source="{StaticResource ImageNeutral}" />
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Trigger>
        </Style.Triggers>
    </Style>
