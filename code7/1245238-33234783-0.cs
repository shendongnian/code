    <DataTemplate x:Key="AddNodeTemplate">
            <Border BorderThickness="1" Background="#F7F7F7">
                <Border.BorderBrush>
                    <DrawingBrush Viewport="8,8,8,8" ViewportUnits="Absolute" TileMode="Tile">
                        <DrawingBrush.Drawing>
                            <DrawingGroup>
                                <GeometryDrawing Brush="#F7F7F7">
                                    <GeometryDrawing.Geometry>
                                        <GeometryGroup>
                                            <RectangleGeometry Rect="0,0,50,50"/>
                                            <RectangleGeometry Rect="50,50,50,50"/>
                                        </GeometryGroup>
                                    </GeometryDrawing.Geometry>
                                </GeometryDrawing>
                            </DrawingGroup>
                        </DrawingBrush.Drawing>
                    </DrawingBrush>
                </Border.BorderBrush>
                <StackPanel>
                    <Button x:Name="ButtonAdd" Click="ButtonAdd_Click" Height="30" Width="130" Tag="{Binding RelativeSource={RelativeSource AncestorType={x:Type syncfusion:Node}}}">
                        <Button.Style>
                            <Style TargetType="Button">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="Button">
                                            <Grid Background="#F7F7F7">
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="25"/>
                                                    <ColumnDefinition/>
                                                </Grid.ColumnDefinitions>
                                                <Image Source="Images/icon_plus.bmp" HorizontalAlignment="Left" Margin="5,0,0,0"/>
                                                <TextBlock Text="Add Property" HorizontalAlignment="Center" Grid.Column="1" VerticalAlignment="Center" Foreground="LightGray" FontStyle="Italic" FontSize="12"/>
                                            </Grid>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                                <Setter Property="Background" Value="#F7F7F7"/>
                            </Style>
                        </Button.Style>
                        <Button.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="Copy Exisiting" ItemsSource="{Binding Path=AvailableProperties}" Click="AddExistingProperty_OnClick" Icon="Images/Copy.bmp" FontFamily="MS Reference Sans Serif">
                                    <MenuItem.Resources>
                                        <Style TargetType="MenuItem">
                                            <Style.Resources>
                                                <Image x:Key="img" x:Shared="False" Width="10" Height="10" Source="{Binding Icon, Converter={StaticResource ImageToSourceConverter}}" 
                                                       Margin="3" VerticalAlignment="Center"/>
                                                <Style TargetType="ContentPresenter">
                                                    <Style.Triggers>
                                                        <Trigger Property="ContentSource" Value="Icon">
                                                            <Setter Property="ContentTemplate">
                                                                <Setter.Value>
                                                                    <DataTemplate>
                                                                        <Image Source="{Binding}"/>
                                                                    </DataTemplate>
                                                                </Setter.Value>
                                                            </Setter>
                                                        </Trigger>
                                                    </Style.Triggers>
                                                </Style>
                                            </Style.Resources>
                                            <Setter Property="Icon" Value="{Binding Icon, Converter={StaticResource ImageToSourceConverter}}"/>
                                            <Style.Triggers>
                                                <Trigger Property="Role" Value="SubMenuItem">
                                                    <Setter Property="HeaderTemplate">
                                                        <Setter.Value>
                                                            <DataTemplate>
                                                                <StackPanel Orientation="Horizontal">
                                                                    <ContentPresenter Content="{Binding Name}"/>
                                                                </StackPanel>
                                                            </DataTemplate>
                                                        </Setter.Value>
                                                    </Setter>
                                                </Trigger>
                                            </Style.Triggers>
                                        </Style>
                                    </MenuItem.Resources>
                                </MenuItem>
                                <MenuItem Header="Upscale well logs" Click="AddProperty_OnClick" Tag="UpscaleWellLogs" Style="{StaticResource MenuItemIcon}" Icon="Images/WellLogs.png" FontFamily="MS Reference Sans Serif"/>
                                <MenuItem Header="Upscale well top attributes" Click="AddProperty_OnClick" Tag="UpscaleWellTopAttributes" Style="{StaticResource MenuItemIcon}" Icon="Images/WellTop.png" FontFamily="MS Reference Sans Serif"/>
                                <MenuItem Header="Upscale point attributes" Click="AddProperty_OnClick" Tag="UpscalePointAttributes" Style="{StaticResource MenuItemIcon}" Icon="Images/PointSet.png" FontFamily="MS Reference Sans Serif"/>
                                <MenuItem Header="Calculate" Click="AddProperty_OnClick" Tag="Calculate" Style="{StaticResource MenuItemIcon}" Icon="Images/calculator.png" FontFamily="MS Reference Sans Serif"/>
                            </ContextMenu>
                        </Button.ContextMenu>
                    </Button>
            </StackPanel>
            </Border>
        </DataTemplate>
    private void AddExistingProperty_OnClick(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            var item = menuItem.DataContext as PropertyNode;
            viewModel.AddPropertyNode(item);
        }
        private void AddProperty_OnClick(object sender, RoutedEventArgs e)
        {
            if (MenuItemActivated != null)
            {
                var menuItem = sender as MenuItem;
                var command = menuItem.Tag as CognitiveTreeMenuCommand?;
                if (command.HasValue)
                {
                    MenuItemActivated(this, new MenuItemEventHandlerArgs() { Command = command.Value });
                }
            }
        }
