    <GroupStyle.ContainerStyle>
                                <Style TargetType="GroupItem">
                                    <Setter Property="IsTabStop" Value="False" />
                                    <Setter Property="Margin" Value="10,0,0,0" />
                                    <Setter Property="Padding" Value="20"/>
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="GroupItem">
                                                <Border Background="{Binding Group, Converter={StaticResource ThemeColorConverter}}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                                                    <Grid>
                                                        <Grid.RowDefinitions>
                                                            <RowDefinition Height="Auto" />
                                                            <RowDefinition Height="*" />
                                                        </Grid.RowDefinitions>
                                                        <ContentControl x:Name="HeaderContent"
                                            Content="{TemplateBinding Content}"
                                            ContentTransitions="{TemplateBinding ContentTransitions}"
                                            ContentTemplate="{TemplateBinding ContentTemplate}"
                                            ContentTemplateSelector="{TemplateBinding ContentTemplateSelector}"
                                            Margin="{TemplateBinding Padding}"
                                            TabIndex="0"
                                            IsTabStop="False" />
                                                        <ItemsControl x:Name="ItemsControl"
                                          Grid.Row="1"
                                          ItemsSource="{Binding GroupItems}"
                                          IsTabStop="False"
                                          TabNavigation="Once"
                                          TabIndex="1" >
                                                            <ItemsControl.ItemContainerTransitions>
                                                                <TransitionCollection>
                                                                    <AddDeleteThemeTransition />
                                                                    <ContentThemeTransition />
                                                                    <ReorderThemeTransition />
                                                                    <EntranceThemeTransition IsStaggeringEnabled="False" />
                                                                </TransitionCollection>
                                                            </ItemsControl.ItemContainerTransitions>
                                                        </ItemsControl>
                                                    </Grid>
                                                </Border>
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
                            </GroupStyle.ContainerStyle>
