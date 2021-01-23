    <ListView Name="flip" SelectionMode="None" ItemsSource="{Binding Profile.photos}" Loaded="flip_Loaded">
            <ListView.Resources>
                <Style x:Key="ListViewStyle1" TargetType="ListView">
                    <Setter Property="IsTabStop" Value="False"/>
                    <Setter Property="TabNavigation" Value="Once"/>
                    <Setter Property="IsSwipeEnabled" Value="True"/>
                    <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                    <Setter Property="VerticalContentAlignment" Value="Top"/>
                    <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Visible"/>
                    <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Disabled"/>
                    <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Auto"/>
                    <Setter Property="ScrollViewer.VerticalScrollMode" Value="Disabled"/>
                    <Setter Property="ScrollViewer.ZoomMode" Value="Disabled"/>
                    <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
                    <Setter Property="ScrollViewer.BringIntoViewOnFocusChange" Value="True"/>
                    <Setter Property="ItemsPanel">
                        <Setter.Value>
                            <ItemsPanelTemplate>
                                <ItemsStackPanel Orientation="Horizontal"/>
                            </ItemsPanelTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListView">
                                <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}">
                                    <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}" IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" TabNavigation="{TemplateBinding TabNavigation}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}" HorizontalSnapPointsType="MandatorySingle">
                                        <ItemsPresenter FooterTransitions="{TemplateBinding FooterTransitions}" FooterTemplate="{TemplateBinding FooterTemplate}" Footer="{TemplateBinding Footer}" HeaderTemplate="{TemplateBinding HeaderTemplate}" Header="{TemplateBinding Header}" HeaderTransitions="{TemplateBinding HeaderTransitions}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Padding="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                    </ScrollViewer>
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.Resources>
            <ListView.Style>
                <StaticResource ResourceKey="ListViewStyle1"/>
            </ListView.Style>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid Width="{Binding ElementName=root,Path=ActualWidth}" Height="{Binding ElementName=root,Path=ActualHeight}">
                       <Image Stretch="Uniform">
                            <Image.Source>
                                <BitmapImage UriSource="{Binding image}" DecodePixelWidth="250" DecodePixelHeight="250" />
                            </Image.Source>
                        </Image>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
