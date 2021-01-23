    <ControlTemplate TargetType="{x:Type Controls:DataGrid}">
    <Border SnapsToDevicePixels="True" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}">
        <ScrollViewer x:Name="DG_ScrollViewer" Focusable="False" RequestBringIntoView="DG_ScrollViewer_RequestBringIntoView">
            <ScrollViewer.Template>
                <ControlTemplate TargetType="{x:Type ScrollViewer}">
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto"/>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="Auto"/>
                        </Grid.ColumnDefinitions>
                        <Button Width="{Binding CellsPanelHorizontalOffset, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Controls:DataGrid}}}" Focusable="False">
                            <Button.Visibility>
                                <Binding Path="HeadersVisibility" RelativeSource="{RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Controls:DataGrid}}">
                                    <Binding.ConverterParameter>
                                        <Controls:DataGridHeadersVisibility>All</Controls:DataGridHeadersVisibility>
                                    </Binding.ConverterParameter>
                                </Binding>
                            </Button.Visibility>
                            <Button.Template>
                                <ControlTemplate TargetType="{x:Type Button}">
                                    <Grid>
                                        <Rectangle x:Name="Border" Fill="{DynamicResource {x:Static SystemColors.ControlBrushKey}}" SnapsToDevicePixels="True"/>
                                        <Polygon x:Name="Arrow" Fill="Black" Stretch="Uniform" HorizontalAlignment="Right" Margin="8,8,3,3" VerticalAlignment="Bottom" Opacity="0.15" Points="0,10 10,10 10,0"/>
                                    </Grid>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsMouseOver" Value="True">
                                            <Setter Property="Stroke" TargetName="Border" Value="{DynamicResource {x:Static SystemColors.ControlDarkBrushKey}}"/>
                                        </Trigger>
                                        <Trigger Property="IsPressed" Value="True">
                                            <Setter Property="Fill" TargetName="Border" Value="{DynamicResource {x:Static SystemColors.ControlDarkBrushKey}}"/>
                                        </Trigger>
                                        <Trigger Property="IsEnabled" Value="False">
                                            <Setter Property="Visibility" TargetName="Arrow" Value="Collapsed"/>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Button.Template>
                            <Button.Command>
                                <RoutedCommand/>
                            </Button.Command>
                        </Button>
                        <Custom:DataGridColumnHeadersPresenter x:Name="PART_ColumnHeadersPresenter" Grid.Column="1">
                            <Custom:DataGridColumnHeadersPresenter.Visibility>
                                <Binding Path="HeadersVisibility" RelativeSource="{RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Controls:DataGrid}}">
                                    <Binding.ConverterParameter>
                                        <Controls:DataGridHeadersVisibility>Column</Controls:DataGridHeadersVisibility>
                                    </Binding.ConverterParameter>
                                </Binding>
                            </Custom:DataGridColumnHeadersPresenter.Visibility>
                        </Custom:DataGridColumnHeadersPresenter>
                        <ScrollContentPresenter x:Name="PART_ScrollContentPresenter" Grid.ColumnSpan="2" Grid.Row="1" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" ContentTemplate="{TemplateBinding ContentTemplate}" CanContentScroll="{TemplateBinding CanContentScroll}" CanHorizontallyScroll="False" CanVerticallyScroll="False"/>
                        <ScrollBar x:Name="PART_VerticalScrollBar" Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}" Grid.Column="2" Grid.Row="1" Maximum="{TemplateBinding ScrollableHeight}" Value="{Binding VerticalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" Orientation="Vertical" ViewportSize="{TemplateBinding ViewportHeight}"/>
                        <Grid Grid.Column="1" Grid.Row="2">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="{Binding NonFrozenColumnsViewportHorizontalOffset, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Controls:DataGrid}}}"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <ScrollBar x:Name="PART_HorizontalScrollBar" Visibility="{TemplateBinding ComputedHorizontalScrollBarVisibility}" Grid.Column="1" Maximum="{TemplateBinding ScrollableWidth}" Value="{Binding HorizontalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" Orientation="Horizontal" ViewportSize="{TemplateBinding ViewportWidth}"/>
                        </Grid>
                    </Grid>
                </ControlTemplate>
            </ScrollViewer.Template>
            <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
        </ScrollViewer>
    </Border>
