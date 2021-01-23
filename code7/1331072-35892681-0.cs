    <StackPanel>
        <CheckBox x:Name="Foo" Content="Click me"/>
        <ComboBox>
            <ComboBox.Style>
                <Style TargetType="{x:Type ComboBox}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsChecked, ElementName=Foo}" Value="True">
                            <Setter Property="IsEnabled" Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ComboBox.Style>
        </ComboBox>
    </StackPanel>
