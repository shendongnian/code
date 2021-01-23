    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ToggleButton">
                <StackPanel Orientation="Horizontal">
                    <TextBlock x:Name="toggleButtonTextBlock" 
                               Text="{Binding RelativeSource={RelativeSource AncestorType={x:Type ToggleButton}}, Path=Content}"/>
                    <CheckBox x:Name="toggleButtonCheckBox" 
                              VerticalAlignment="Center" 
                              Margin="2" 
                              IsChecked="{Binding RelativeSource={RelativeSource AncestorType={x:Type ToggleButton}}, Path=IsChecked, Mode=TwoWay}" >
                    </CheckBox>
                </StackPanel>
                <ControlTemplate.Triggers>
                    <!-- Will return to previous state if false -->
                    <Trigger Property="ToggleButton.IsChecked" Value="True">
                        <Setter TargetName="toggleButtonTextBlock" 
                                Property="TextDecorations" 
                                Value="Underline"/>
                    </Trigger>
                    <Trigger Property="ToggleButton.IsMouseOver" Value="True">
                        <Setter TargetName="toggleButtonTextBlock" 
                                Property="TextDecorations"
                                Value="Underline"/>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
