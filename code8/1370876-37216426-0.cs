     <Style x:Key="ComboBoxTest2" TargetType="{x:Type ComboBox}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ComboBox}">
                        <Grid>
                            <ToggleButton Grid.Column="2" Focusable="false" IsChecked="{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}" >
                                <ToggleButton.Template>
                                    <ControlTemplate>
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="5*" />
                                                <ColumnDefinition Width="*" />
                                            </Grid.ColumnDefinitions>
                                            <Border x:Name="Border"  Grid.ColumnSpan="2" CornerRadius="5" Background="#FF303030" BorderBrush="Black" BorderThickness="1" />
                                            <Border Grid.Column="0" CornerRadius="5,0,0,5"  Margin="1"  Background="Black"  BorderBrush="Black" BorderThickness="0,0,1,0" />
                                            <Path x:Name="Arrow" Grid.Column="1"  Fill="#FFEAEAEA" HorizontalAlignment="Center" VerticalAlignment="Center" Data="M 0 0 L 4 4 L 8 0 Z"/>
                                        </Grid>
                                        <ControlTemplate.Triggers>
                                            <Trigger Property="IsMouseOver" Value="true">
                                                <Setter TargetName="Border" Property="Background" Value="Green" />
                                            </Trigger>
                                            <Trigger Property="ToggleButton.IsChecked" Value="true">
                                                <Setter TargetName="Border" Property="Background" Value="Green" />
                                            </Trigger>
                                        </ControlTemplate.Triggers>
                                    </ControlTemplate>
                                </ToggleButton.Template>
                            </ToggleButton>
                            <ContentPresenter x:Name="ContentSite" IsHitTestVisible="False"  Content="{TemplateBinding SelectionBoxItem}" ContentTemplate="{TemplateBinding SelectionBoxItemTemplate}" ContentTemplateSelector="{TemplateBinding ItemTemplateSelector}" Margin="3"  />
                            <TextBox x:Name="PART_EditableTextBox" Visibility="Hidden" IsReadOnly="{TemplateBinding IsReadOnly}"/>
                            <Popup x:Name="Popup" Placement="Bottom" IsOpen="{TemplateBinding IsDropDownOpen}" AllowsTransparency="True"  Focusable="False" PopupAnimation="Slide">
                                <Grid  x:Name="DropDown" SnapsToDevicePixels="True" MinWidth="{TemplateBinding ActualWidth}" MaxHeight="{TemplateBinding MaxDropDownHeight}">
                                    <Border x:Name="DropDownBorder" Background="#FF303030" />
                                    <ScrollViewer SnapsToDevicePixels="True">
                                        <StackPanel IsItemsHost="True" />
                                    </ScrollViewer>
                                </Grid>
                            </Popup>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
