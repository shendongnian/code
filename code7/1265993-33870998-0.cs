    <TextBox x:Name="LandTextBox" >
            <TextBox.Style>
                <Style TargetType="{x:Type TextBox}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=LandComboBox, Path=SelectedItem.Content}" Value="Test 1.2.">
                            <Setter Property="ToolTip" Value="Hello 1.2." />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding ElementName=LandComboBox, Path=SelectedItem.Content}" Value="Test 55">
                            <Setter Property="ToolTip" Value="Hello 55" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
