        <ControlTemplate x:Key="CustomTabControlTemplate"  TargetType="TabControl" >
            <Grid ClipToBounds="True" SnapsToDevicePixels="True" KeyboardNavigation.TabNavigation="Local" >
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Name="ColumnDefinition0" />
                    <ColumnDefinition Width="0" Name="ColumnDefinition1" />
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" Name="RowDefinition0" />
                    <RowDefinition Height="*" Name="RowDefinition1" />
                </Grid.RowDefinitions>
                <TabPanel IsItemsHost="True" Name="HeaderPanel" Margin="2,2,2,0" Panel.ZIndex="1" KeyboardNavigation.TabIndex="1" Grid.Column="0" Grid.Row="0" Background="Aqua" />
                <Border BorderThickness="{TemplateBinding Border.BorderThickness}" BorderBrush="{TemplateBinding Border.BorderBrush}" Background="{TemplateBinding Panel.Background}" Name="ContentPanel" KeyboardNavigation.TabIndex="2" KeyboardNavigation.TabNavigation="Local" KeyboardNavigation.DirectionalNavigation="Contained" Grid.Column="0" Grid.Row="1">
                    <ContentPresenter Content="{TemplateBinding TabControl.SelectedContent}" ContentTemplate="{TemplateBinding TabControl.SelectedContentTemplate}" ContentStringFormat="{TemplateBinding TabControl.SelectedContentStringFormat}" ContentSource="SelectedContent" Name="PART_SelectedContentHost" Margin="{TemplateBinding Control.Padding}" SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
                </Border>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property="TabControl.TabStripPlacement">
                    <Setter Property="Grid.Row" TargetName="HeaderPanel">
                        <Setter.Value>
                            <s:Int32>1</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Row" TargetName="ContentPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RowDefinition.Height" TargetName="RowDefinition0">
                        <Setter.Value>
                            <GridLength>*</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RowDefinition.Height" TargetName="RowDefinition1">
                        <Setter.Value>
                            <GridLength>Auto</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="FrameworkElement.Margin" TargetName="HeaderPanel">
                        <Setter.Value>
                            <Thickness>2,0,2,2</Thickness>
                        </Setter.Value>
                    </Setter>
                    <Trigger.Value>
                        <x:Static Member="Dock.Bottom" />
                    </Trigger.Value>
                </Trigger>
                <Trigger Property="TabControl.TabStripPlacement">
                    <Setter Property="Grid.Row" TargetName="HeaderPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Row" TargetName="ContentPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Column" TargetName="HeaderPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Column" TargetName="ContentPanel">
                        <Setter.Value>
                            <s:Int32>1</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="ColumnDefinition.Width" TargetName="ColumnDefinition0">
                        <Setter.Value>
                            <GridLength>Auto</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="ColumnDefinition.Width" TargetName="ColumnDefinition1">
                        <Setter.Value>
                            <GridLength>*</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RowDefinition.Height" TargetName="RowDefinition0">
                        <Setter.Value>
                            <GridLength>*</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RowDefinition.Height" TargetName="RowDefinition1">
                        <Setter.Value>
                            <GridLength>0</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="FrameworkElement.Margin" TargetName="HeaderPanel">
                        <Setter.Value>
                            <Thickness>2,2,0,2</Thickness>
                        </Setter.Value>
                    </Setter>
                    <Trigger.Value>
                        <x:Static Member="Dock.Left" />
                    </Trigger.Value>
                </Trigger>
                <Trigger Property="TabControl.TabStripPlacement">
                    <Setter Property="Grid.Row" TargetName="HeaderPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Row" TargetName="ContentPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Column" TargetName="HeaderPanel">
                        <Setter.Value>
                            <s:Int32>1</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Grid.Column" TargetName="ContentPanel">
                        <Setter.Value>
                            <s:Int32>0</s:Int32>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="ColumnDefinition.Width" TargetName="ColumnDefinition0">
                        <Setter.Value>
                            <GridLength>*</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="ColumnDefinition.Width" TargetName="ColumnDefinition1">
                        <Setter.Value>
                            <GridLength>Auto</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RowDefinition.Height" TargetName="RowDefinition0">
                        <Setter.Value>
                            <GridLength>*</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RowDefinition.Height" TargetName="RowDefinition1">
                        <Setter.Value>
                            <GridLength>0</GridLength>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="FrameworkElement.Margin" TargetName="HeaderPanel">
                        <Setter.Value>
                            <Thickness>0,2,2,2</Thickness>
                        </Setter.Value>
                    </Setter>
                    <Trigger.Value>
                        <x:Static Member="Dock.Right" />
                    </Trigger.Value>
                </Trigger>
                <Trigger Property="UIElement.IsEnabled">
                    <Setter Property="TextElement.Foreground">
                        <Setter.Value>
                            <DynamicResource ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
                        </Setter.Value>
                    </Setter>
                    <Trigger.Value>
                        <s:Boolean>False</s:Boolean>
                    </Trigger.Value>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
