    <FlyoutBase.AttachedFlyout>
                    <MenuFlyout>
                        <MenuFlyout.MenuFlyoutPresenterStyle>
                            <Style TargetType="MenuFlyoutPresenter">
                                <Setter Property="Background" Value="Transparent"/>
                            </Style>
                        </MenuFlyout.MenuFlyoutPresenterStyle>
                        <MenuFlyoutItem Text="Delete" Click="DeleteMenuItemClick">
                            <MenuFlyoutItem.Template>
                                <ControlTemplate TargetType="MenuFlyoutItem">
                                    <Grid>
                                        <StackPanel Orientation="Horizontal" Padding="0">
                                            <SymbolIcon Symbol="Delete" Margin="10,0" />
                                            <TextBlock Text="{TemplateBinding Text}" />
                                        </StackPanel>
                                        <VisualStateManager.VisualStateGroups>
                                            <VisualStateGroup x:Name="CommonStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition To="PointerOver" GeneratedDuration="0:0:0.5"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="Normal" />
                                                <VisualState x:Name="PointerOver">
                                                    <Storyboard>
                                                        <ColorAnimation Storyboard.TargetName="Flyout" Storyboard.TargetProperty="Color" To="{StaticResource SystemAltHighColor}" />
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                        </VisualStateManager.VisualStateGroups>
                                        <Grid.Background>
                                            <SolidColorBrush x:Name="Flyout" Color="{TemplateBinding Background}"></SolidColorBrush>
                                        </Grid.Background>
                                    </Grid>
                                </ControlTemplate>
                            </MenuFlyoutItem.Template>
                        </MenuFlyoutItem>
                    </MenuFlyout>
                </FlyoutBase.AttachedFlyout>
