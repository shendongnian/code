    <TextBox Grid.Row="0"
             Grid.Column="1"
             Name="textbox_differentProperties">
        <TextBox.Style>
            <Style TargetType="{x:Type TextBox}">
                <Setter Property="Text">
                    <Setter.Value>
                        <Binding Path="A">
                            <Binding.ValidationRules>
                                <ExceptionValidationRule />
                            </Binding.ValidationRules>
                        </Binding>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsChecked, ElementName=checkbox_next}"
                                 Value="True">
                        <Setter Property="Text">
                            <Setter.Value>
                                <Binding Path="C">
                                    <Binding.ValidationRules>
                                        <ExceptionValidationRule />
                                    </Binding.ValidationRules>
                                </Binding>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </TextBox.Style>
    </TextBox>
