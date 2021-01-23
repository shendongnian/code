    <Style TargetType="ListViewItem" x:Key="CustomListViewItemExpanded">
        <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}" />
        <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
        <Setter Property="Background" Value="Transparent"/>
        <Setter Property="Foreground" Value="Transparent" />
        <Setter Property="TabNavigation" Value="Local"/>
        <Setter Property="IsHoldingEnabled" Value="True"/>
        <Setter Property="Padding" Value="0"/>
        <Setter Property="Margin" Value="0"/>
        <Setter Property="HorizontalAlignment" Value="Stretch"/>
        <Setter Property="VerticalAlignment" Value="Stretch"/>
        <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
        <Setter Property="VerticalContentAlignment" Value="Stretch"/>
        <Setter Property="MinWidth" Value="0"/>
        <Setter Property="MinHeight" Value="0"/>
        <Setter Property="UseSystemFocusVisuals" Value="True" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ListViewItem">
                    <Grid x:Name="ContentBorder"
                            BorderThickness="0">
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Normal">
                                    <Storyboard>
                                        <PointerUpThemeAnimation Storyboard.TargetName="ContentPresenter" />
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="PointerOver">
                                    <Storyboard>
                                        <PointerUpThemeAnimation Storyboard.TargetName="ContentPresenter" />
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Pressed">
                                    <Storyboard>
                                        <PointerDownThemeAnimation TargetName="ContentPresenter" />
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Selected">
                                    <Storyboard>
                                        <PointerUpThemeAnimation Storyboard.TargetName="ContentPresenter" />
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="PointerOverSelected">
                                    <Storyboard>
                                        <PointerUpThemeAnimation Storyboard.TargetName="ContentPresenter" />
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="PressedSelected">
                                    <Storyboard>
                                        <PointerDownThemeAnimation TargetName="ContentPresenter" />
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="DisabledStates">
                                <VisualState x:Name="Enabled"/>
                                <VisualState x:Name="Disabled"/>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="MultiSelectStates">
                                <VisualState x:Name="MultiSelectDisabled"/>
                                <VisualState x:Name="MultiSelectEnabled"/>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="DataVirtualizationStates">
                                <VisualState x:Name="DataAvailable"/>
                                <VisualState x:Name="DataPlaceholder"/>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="ReorderHintStates">
                                <VisualState x:Name="NoReorderHint"/>
                                <VisualState x:Name="BottomReorderHint"/>
                                <VisualState x:Name="TopReorderHint"/>
                                <VisualState x:Name="RightReorderHint"/>
                                <VisualState x:Name="LeftReorderHint"/>
                                <VisualStateGroup.Transitions>
                                    <VisualTransition To="NoReorderHint" GeneratedDuration="0:0:0.2"/>
                                </VisualStateGroup.Transitions>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="DragStates">
                                <VisualState x:Name="NotDragging" />
                                <VisualState x:Name="Dragging"/>
                                <VisualState x:Name="DraggingTarget"/>
                                <VisualState x:Name="MultipleDraggingPrimary"/>
                                <VisualState x:Name="MultipleDraggingSecondary"/>
                                <VisualState x:Name="DraggedPlaceholder"/>
                                    <VisualStateGroup.Transitions>
                                    <VisualTransition To="NotDragging" GeneratedDuration="0:0:0.2"/>
                                </VisualStateGroup.Transitions>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <ContentPresenter x:Name="ContentPresenter"
                                            ContentTransitions="{TemplateBinding ContentTransitions}"
                                            ContentTemplate="{TemplateBinding ContentTemplate}"
                                            Content="{TemplateBinding Content}"
                                            HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                            VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                            Margin="{TemplateBinding Padding}"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
