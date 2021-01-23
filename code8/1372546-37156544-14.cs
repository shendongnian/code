    <Grid>
      <Grid.Resources> 
         <Style x:Key="CustomTextBoxTextStyle" TargetType="TextBox">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TextBox}">
                            <Border x:Name="bg" BorderBrush="#FF825E5E" BorderThickness="1">
                                <ScrollViewer x:Name="PART_ContentHost" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="Validation.HasError" Value="True">
                                    <Trigger.Setters>
                                        <Setter Property="ToolTip" Value="{Binding RelativeSource={RelativeSource Self},Path=(Validation.Errors)[0].ErrorContent}"/>                                        
                                        <Setter Property="BorderThickness" TargetName="bg" Value="2"/>
                                        <Setter Property="BorderBrush" TargetName="bg" Value="Red"/>
                                    </Trigger.Setters>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
    </Grid>
    <TextBox Style="{StaticResource CustomTextBoxTextStyle}" Height="23" Name="textBox1" Margin="25">
                <Validation.ErrorTemplate>
                    <ControlTemplate>
                        <DockPanel>
                            <TextBlock Foreground="Red" DockPanel.Dock="Right">!</TextBlock>
                            <AdornedElementPlaceholder x:Name="ErrorAdorner"
        ></AdornedElementPlaceholder>
                        </DockPanel>
                    </ControlTemplate>
                </Validation.ErrorTemplate>
                
                <TextBox.Text>
                    <Binding Path="Name" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged">
                        <Binding.ValidationRules>
                            <local:NameValidator></local:NameValidator>
                        </Binding.ValidationRules>
                    </Binding>
                </TextBox.Text>
    </TextBox>
