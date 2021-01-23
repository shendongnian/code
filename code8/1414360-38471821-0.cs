        <controls:DataGrid.Resources>
                <Converters:VisibilityConverter x:Key="vc" />
                <Converters:NotConverter x:Key="nc" />
                
                <!-- TransparentListBox -->
                <Style x:Key="TransparentListBox" TargetType="ListBox">
                    <Setter Property="Foreground" Value="{StaticResource ListBoxForegroundThemeBrush}"/>
                    <Setter Property="Background" Value="Transparent"/>
                    <Setter Property="BorderBrush" Value="{StaticResource ListBoxBorderThemeBrush}"/>
                    <Setter Property="BorderThickness" Value="{StaticResource ListBoxBorderThemeThickness}"/>
                    <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
                    <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto"/>
                    <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Disabled"/>
                    <Setter Property="ScrollViewer.IsHorizontalRailEnabled" Value="True"/>
                    <Setter Property="ScrollViewer.VerticalScrollMode" Value="Enabled"/>
                    <Setter Property="ScrollViewer.IsVerticalRailEnabled" Value="True"/>
                    <Setter Property="ScrollViewer.ZoomMode" Value="Disabled"/>
                    <Setter Property="IsTabStop" Value="False"/>
                    <Setter Property="TabNavigation" Value="Once"/>
                    <Setter Property="FontFamily" Value="{StaticResource ContentControlThemeFontFamily}"/>
                    <Setter Property="FontSize" Value="{StaticResource ControlContentThemeFontSize}"/>
                    <Setter Property="ItemsPanel">
                        <Setter.Value>
                            <ItemsPanelTemplate>
                                <VirtualizingStackPanel/>
                            </ItemsPanelTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListBox">
                                <Border x:Name="LayoutRoot" BorderBrush="{TemplateBinding BorderBrush}" 
                            BorderThickness="{TemplateBinding BorderThickness}" 
                            Background="{TemplateBinding Background}">
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="CommonStates">
                                            <VisualState x:Name="Normal"/>
                                            <VisualState x:Name="Disabled">
                                                <Storyboard>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="LayoutRoot">
                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="Transparent"/>
                                                    </ObjectAnimationUsingKeyFrames>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="LayoutRoot">
                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource ListBoxDisabledForegroundThemeBrush}"/>
                                                    </ObjectAnimationUsingKeyFrames>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="FocusStates">
                                            <VisualState x:Name="Focused"/>
                                            <VisualState x:Name="Unfocused"/>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                    <ScrollViewer x:Name="ScrollViewer" 
                                      HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" 
                                      HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                      IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" 
                                      IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" 
                                      Padding="{TemplateBinding Padding}" TabNavigation="{TemplateBinding TabNavigation}" 
                                      VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" 
                                      VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" 
                                      ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                                        <ItemsPresenter/>
                                    </ScrollViewer>
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
                
                <Style x:Key="DataGridStyle1" TargetType="controls:DataGrid">
                    <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
                    <Setter Property="HeaderBackground" Value="{ThemeResource SystemControlHighlightChromeHighBrush}" />
                    <Setter Property="RowBackgroundOddBrush" Value="{ThemeResource SystemControlPageBackgroundChromeLowBrush}" />
                    <Setter Property="CellTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <ContentPresenter Margin="12" Content="{Binding Control}" />
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="controls:DataGrid">
                                <Grid Background="{TemplateBinding Background}">
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="Auto" />
                                        <RowDefinition Height="*" />
                                    </Grid.RowDefinitions>
                                    <Grid Grid.Row="0" Visibility="Collapsed" Background="{TemplateBinding HeaderBackground}" Height="40" x:Name="ColumnHeaders">
                                        <!-- HACK: Needed so that column DPs are working when adding columns in code only. -->
                                        <ContentPresenter>
                                            <controls:DataGridTextColumn />
                                        </ContentPresenter>
                                    </Grid>
                                    <controls:MtListBox BorderThickness="0" Grid.Row="1"
                                            ItemContainerStyle="{TemplateBinding RowStyle}"
                                            HorizontalContentAlignment="Stretch" 
                                            VerticalContentAlignment="Stretch"
                                            Foreground="{ThemeResource SystemControlForegroundBaseHighBrush}"
                                            Style="{StaticResource TransparentListBox}" 
                                            Margin="0" x:Name="Rows" />
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="HeaderTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <Grid Background="Transparent">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="Auto" />
                                        <ColumnDefinition Width="*" />
                                    </Grid.ColumnDefinitions>
                                    <ContentPresenter Grid.Column="0" 
                                            Margin="12,0,12,2" 
                                            VerticalAlignment="Center" 
                                            FontSize="{ThemeResource TextStyleLargeFontSize}" 
                                            Content="{Binding Header}" />
                                    <StackPanel Grid.Column="1" 
                                            Visibility="{Binding IsSelected, Converter={StaticResource vc}}" 
                                            VerticalAlignment="Center" 
                                            HorizontalAlignment="Left">
                                        <Path Data="M4,0 L0,8 L8,8 Z" Fill="White" Visibility="{Binding IsAscending, Converter={StaticResource vc}}"/>
                                        <Path Data="M0,0 L4,8 L8,0 Z" Fill="White" Visibility="{Binding IsAscending, Converter={StaticResource nc}}"/>
                                    </StackPanel>
                                </Grid>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </controls:DataGrid.Resources>
            <controls:DataGrid.Style>
                <StaticResource ResourceKey="DataGridStyle1"/>
            </controls:DataGrid.Style>
