    <TextBox Tag="Name" BorderThickness="0, 0, 0, 1" BorderBrush="Blue" HorizontalAlignment="Stretch" 
                Margin="10" Padding="2" Foreground="Blue">
        <TextBox.Style>
            <Style TargetType="TextBox" BasedOn="{StaticResource {x:Type TextBox}}">
                <Setter Property="Control.Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TextBox}">
                            <Border BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}"
                                    Margin="{TemplateBinding Margin}" Padding="{TemplateBinding Padding}">
                                <Grid>
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="Auto" />
                                        <RowDefinition Height="Auto" />
                                    </Grid.RowDefinitions>
                                    <TextBlock Text="{TemplateBinding Tag}" Focusable="False" Foreground="{TemplateBinding Foreground}" />
                                    <ScrollViewer Name="PART_ContentHost" Focusable="False" 
                                                    ScrollViewer.HorizontalScrollBarVisibility="Hidden"
                                                    ScrollViewer.VerticalScrollBarVisibility="Hidden" 
                                                    Background="#00FFFFFF" />
                                </Grid>
                            </Border>
                                    
                            <ControlTemplate.Triggers>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="IsFocused" Value="true" />
                                        <Condition Property="Text" Value="" />
                                    </MultiTrigger.Conditions>
                                    <MultiTrigger.Setters>
                                        <Setter TargetName="PART_ContentHost" Property="Grid.Row" Value="1" />
                                    </MultiTrigger.Setters>
                                </MultiTrigger>
                                <DataTrigger>
                                    <DataTrigger.Binding>
                                        <Binding Path="Text" RelativeSource="{RelativeSource Self}" Converter="{StaticResource ValueToEqualsParameterConverter}">
                                            <Binding.ConverterParameter>
                                                <x:Static Member="sys:String.Empty" />
                                            </Binding.ConverterParameter>
                                        </Binding>
                                    </DataTrigger.Binding>
                                    <DataTrigger.Value>
                                        <sys:Boolean>False</sys:Boolean>
                                    </DataTrigger.Value>
                                    <DataTrigger.Setters>
                                        <Setter TargetName="PART_ContentHost" Property="Grid.Row" Value="1" />
                                    </DataTrigger.Setters>
                                </DataTrigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TextBox.Style>
    </TextBox>
