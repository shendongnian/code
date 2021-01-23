    <ListView.Resources>
        <!-- Better to put this to another XAML file -->
        <Style x:Key="ListViewItemStyleDefault" TargetType="ListViewItem">
            <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
            <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="Foreground" Value="{ThemeResource SystemControlForegroundBaseHighBrush}"/>
            <Setter Property="TabNavigation" Value="Local"/>
            <Setter Property="IsHoldingEnabled" Value="True"/>
            <Setter Property="Padding" Value="12,0,12,0"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="MinWidth" Value="{ThemeResource ListViewItemMinWidth}"/>
            <Setter Property="MinHeight" Value="{ThemeResource ListViewItemMinHeight}"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListViewItem">
                        <ListViewItemPresenter CheckBrush="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" ContentMargin="{TemplateBinding Padding}" CheckMode="Inline" ContentTransitions="{TemplateBinding ContentTransitions}" CheckBoxBrush="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" DragForeground="{ThemeResource ListViewItemDragForegroundThemeBrush}" DragOpacity="{ThemeResource ListViewItemDragThemeOpacity}" DragBackground="{ThemeResource ListViewItemDragBackgroundThemeBrush}" DisabledOpacity="{ThemeResource ListViewItemDisabledThemeOpacity}" FocusBorderBrush="{ThemeResource SystemControlForegroundAltHighBrush}" FocusSecondaryBorderBrush="{ThemeResource SystemControlForegroundBaseHighBrush}" HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" PointerOverForeground="{ThemeResource SystemControlHighlightAltBaseHighBrush}" PressedBackground="{ThemeResource SystemControlHighlightListMediumBrush}" PlaceholderBackground="{ThemeResource ListViewItemPlaceholderBackgroundThemeBrush}" PointerOverBackground="{ThemeResource SystemControlHighlightListLowBrush}" ReorderHintOffset="{ThemeResource ListViewItemReorderHintThemeOffset}" SelectedPressedBackground="{ThemeResource SystemControlHighlightListAccentHighBrush}" SelectionCheckMarkVisualEnabled="True" SelectedForeground="{ThemeResource SystemControlHighlightAltBaseHighBrush}" SelectedPointerOverBackground="{ThemeResource SystemControlHighlightListAccentMediumBrush}" SelectedBackground="{ThemeResource SystemControlHighlightListAccentLowBrush}" VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="ListViewItemStyleStretch" TargetType="ListViewItem" BasedOn="{StaticResource ListViewItemStyleDefault}">
            <!-- Magic here -->
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
        </Style>
    </ListView.Resources>
    <ListView.ItemContainerStyle>
        <StaticResource ResourceKey="ListViewItemStyleStretch"/>
    </ListView.ItemContainerStyle>
    <ListView.ItemTemplate>
        <!-- Your ItemTemplate... -->
    </ListView.ItemTemplate>
