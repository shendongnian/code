    <Window.Resources>
        <Style TargetType="{x:Type ListView}">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderBrush" Value="#FFABADB3"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
            <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Auto"/>
            <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto"/>
            <Setter Property="ScrollViewer.CanContentScroll" Value="True"/>
            <Setter Property="ScrollViewer.PanningMode" Value="Both"/>
            <Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListView}">
                        <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" Height="{TemplateBinding Height}" BorderThickness="0" Background="{TemplateBinding Background}" Padding="0" SnapsToDevicePixels="True">
                            <ScrollViewer Focusable="False" Padding="0" >
                                <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                            </ScrollViewer>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsEnabled" Value="False">
                                <Setter Property="Background" TargetName="Bd" Value="White"/>
                                <Setter Property="BorderBrush" TargetName="Bd" Value="#FFD9D9D9"/>
                            </Trigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsGrouping" Value="True"/>
                                    <Condition Property="VirtualizingPanel.IsVirtualizingWhenGrouping" Value="False"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="ScrollViewer.CanContentScroll" Value="False"/>
                            </MultiTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style TargetType="{x:Type ListViewItem}">
            <Setter Property="SnapsToDevicePixels" Value="True"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="HorizontalContentAlignment" Value="{Binding HorizontalContentAlignment, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type ItemsControl}}}"/>
            <Setter Property="VerticalContentAlignment" Value="{Binding VerticalContentAlignment, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type ItemsControl}}}"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderBrush" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="FocusVisualStyle">
                <Setter.Value>
                    <Style>
                        <Setter Property="Control.Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Rectangle Margin="2" SnapsToDevicePixels="True" Stroke="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}" StrokeThickness="1" StrokeDashArray="1 2"/>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListViewItem}">
                        <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="1"  Background="{TemplateBinding Background}" Margin="0,-1,5,-1" SnapsToDevicePixels="True">
                            <ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsMouseOver" Value="True"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="Background" TargetName="Bd" Value="#1F26A0DA"/>
                                <Setter Property="BorderBrush" TargetName="Bd" Value="#A826A0DA"/>
                            </MultiTrigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="Selector.IsSelectionActive" Value="False"/>
                                    <Condition Property="IsSelected" Value="True"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="Background" TargetName="Bd" Value="#3DDADADA"/>
                                <Setter Property="BorderBrush" TargetName="Bd" Value="#FFDADADA"/>
                            </MultiTrigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="Selector.IsSelectionActive" Value="True"/>
                                    <Condition Property="IsSelected" Value="True"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="Background" TargetName="Bd" Value="#3D26A0DA"/>
                                <Setter Property="BorderBrush" TargetName="Bd" Value="#FF26A0DA"/>
                            </MultiTrigger>
                            <Trigger Property="IsEnabled" Value="False">
                                <Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
