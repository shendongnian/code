            <ListBox x:Name="listBox" Margin="0">
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                    <Style.Resources>
                        <SolidColorBrush x:Key="Item.MouseOver.Background" Color="Yellow"/>
                        <SolidColorBrush x:Key="Item.MouseOver.Border" Color="Red"/>
                        <SolidColorBrush x:Key="Item.MouseOver.Foreground" Color="Blue"/>
                        <SolidColorBrush x:Key="Item.SelectedInactive.Background" Color="#3DDADADA"/>
                        <SolidColorBrush x:Key="Item.SelectedInactive.Border" Color="#FFDADADA"/>
                        <SolidColorBrush x:Key="Item.SelectedActive.Background" Color="LightGreen"/>
                        <SolidColorBrush x:Key="Item.SelectedActive.Border" Color="DarkGreen"/>
                    </Style.Resources>
                    <Setter Property="SnapsToDevicePixels" Value="True"/>
                    <Setter Property="Padding" Value="4,1"/>
                    <Setter Property="HorizontalContentAlignment" Value="{Binding HorizontalContentAlignment, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}}"/>
                    <Setter Property="VerticalContentAlignment" Value="{Binding VerticalContentAlignment, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}}"/>
                    <Setter Property="Background" Value="Transparent"/>
                    <Setter Property="BorderBrush" Value="Transparent"/>
                    <Setter Property="BorderThickness" Value="1"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type ListBoxItem}">
                                <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                                    <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                </Border>
                                <ControlTemplate.Triggers>
                                    <MultiTrigger>
                                        <MultiTrigger.Conditions>
                                            <Condition Property="IsMouseOver" Value="True"/>
                                        </MultiTrigger.Conditions>
                                        <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.MouseOver.Background}"/>
                                        <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource Item.MouseOver.Border}"/>
                                        <Setter Property="Foreground" Value="Blue"/>
                                        <Setter Property="FontWeight" Value="Bold"></Setter>
                                    </MultiTrigger>
                                    <MultiTrigger>
                                        <MultiTrigger.Conditions>
                                            <Condition Property="Selector.IsSelectionActive" Value="False"/>
                                            <Condition Property="IsSelected" Value="True"/>
                                        </MultiTrigger.Conditions>
                                        <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.SelectedInactive.Background}"/>
                                        <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource Item.SelectedInactive.Border}"/>
                                    </MultiTrigger>
                                    <MultiTrigger>
                                        <MultiTrigger.Conditions>
                                            <Condition Property="Selector.IsSelectionActive" Value="True"/>
                                            <Condition Property="IsSelected" Value="True"/>
                                        </MultiTrigger.Conditions>
                                        <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.SelectedActive.Background}"/>
                                        <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource Item.SelectedActive.Border}"/>
                                        <Setter Property="Foreground" Value="Red"/>
                                        <Setter Property="FontWeight" Value="Bold"></Setter>
                                    </MultiTrigger>
                                    <Trigger Property="IsEnabled" Value="False">
                                        <Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>
