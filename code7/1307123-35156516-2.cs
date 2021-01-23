                <ListView ItemsSource="{Binding ElementName=This, Path=Shapes}" SelectionMode="Extended" MouseDown="UIElement_OnMouseDown" SelectionChanged="Selector_OnSelectionChanged">
                <ListView.Resources>
                    <ControlTemplate x:Key="SelectedTemplate" TargetType="ListViewItem">
                        <ContentControl Content="{Binding }"></ContentControl>
                    </ControlTemplate>
                </ListView.Resources>
                <ListView.ItemsPanel>
                    <ItemsPanelTemplate>
                        <Canvas Background="White" />
                    </ItemsPanelTemplate>
                </ListView.ItemsPanel>
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Style.Triggers>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsSelected" Value="true" />
                                    <Condition Property="Selector.IsSelectionActive" Value="true" />
                                </MultiTrigger.Conditions>
                                <Setter Property="Template" Value="{StaticResource SelectedTemplate}" />
                            </MultiTrigger>
                        </Style.Triggers>
                    </Style>
                </ListView.ItemContainerStyle>
            </ListView>
