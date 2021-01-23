    <ListView  Style="{StaticResource ListViewStyle1}">
    ...
    </ListView>
    
    <Style x:Key="ListViewStyle1" TargetType="ListView">
                <Setter Property="IsTabStop" Value="False"/>
                <Setter Property="TabNavigation" Value="Once"/>
                <Setter Property="IsSwipeEnabled" Value="True"/>
                <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                <Setter Property="VerticalContentAlignment" Value="Bottom"/>
                <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
                <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto"/>
                <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Disabled"/>
                <Setter Property="ScrollViewer.VerticalScrollMode" Value="Auto"/>
                <Setter Property="ScrollViewer.ZoomMode" Value="Disabled"/>
                <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
                <Setter Property="ScrollViewer.BringIntoViewOnFocusChange" Value="True"/>
                <Setter Property="ItemContainerTransitions">
                    <Setter.Value>
                        <TransitionCollection>
                            <AddDeleteThemeTransition/>
                            <ReorderThemeTransition/>
                        </TransitionCollection>
                    </Setter.Value>
                </Setter>
                <Setter Property="ItemsPanel">
                    <Setter.Value>
                        <ItemsPanelTemplate>
                            <ItemsStackPanel Orientation="Vertical"/>
                        </ItemsPanelTemplate>
                    </Setter.Value>
                </Setter>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListView">
                            <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}">
                                <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}" IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" TabNavigation="{TemplateBinding TabNavigation}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                                    <ItemsPresenter FooterTransitions="{TemplateBinding FooterTransitions}" FooterTemplate="{TemplateBinding FooterTemplate}" Footer="{TemplateBinding Footer}" HeaderTemplate="{TemplateBinding HeaderTemplate}" Header="{TemplateBinding Header}" HeaderTransitions="{TemplateBinding HeaderTransitions}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Padding="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                </ScrollViewer>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
