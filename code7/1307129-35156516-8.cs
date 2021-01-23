    <Window x:Class="ListViewWithCanvasPanel.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:listViewWithCanvasPanel="clr-namespace:ListViewWithCanvasPanel"
        Title="MainWindow" Height="350" Width="525" x:Name="This" ResizeMode="CanResize">
    <Grid>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="2.5*"></ColumnDefinition>
                <ColumnDefinition Width="4*"></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <ListView x:Name="DetailsList" Panel.ZIndex="999" Grid.Column="0" ItemsSource="{Binding ElementName=This, Path=Shapes}" SelectionMode="Extended" SelectionChanged="Selector_OnSelectionChanged">
                <ListView.Resources>
                    <DataTemplate x:Key="ShapeDataPresentationDataTemplate" DataType="listViewWithCanvasPanel:ShapeDataPresentation">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition></ColumnDefinition>
                                <ColumnDefinition></ColumnDefinition>
                                <ColumnDefinition></ColumnDefinition>
                            </Grid.ColumnDefinitions>
                            <TextBlock Grid.Column="0" Text="{Binding Name, StringFormat={}{0:N0}%}"></TextBlock>
                            <TextBlock Grid.Column="1">
                                <Run Text="W:"></Run>
                                <Run Text="{Binding OriginalRectAroundShape.Width}"></Run>
                            </TextBlock>
                            <TextBlock Grid.Column="2">
                                <Run Text="H:"></Run>
                                <Run Text="{Binding OriginalRectAroundShape.Height}"></Run>
                            </TextBlock>
                        </Grid>
                    </DataTemplate>
                </ListView.Resources>
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate DataType="Shape">
                                   <ContentControl Content="{Binding Tag}" ContentTemplate="{StaticResource ShapeDataPresentationDataTemplate}"></ContentControl>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ListView.ItemContainerStyle>
            </ListView>
            <GridSplitter Grid.Column="0" Width="3" Background="Blue" Panel.ZIndex="999"
              VerticalAlignment="Stretch" HorizontalAlignment="Right" Margin="0"/>
            <ItemsControl Grid.Column="1" x:Name="ShapesPresentor" ItemsSource="{Binding ElementName=This, Path=Shapes}"
                      HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
                      MouseDown="UIElement_OnMouseDown">
                <!--<ListView.Resources>
                    <ControlTemplate x:Key="SelectedTemplate" TargetType="ListViewItem">
                        <ContentControl Content="{Binding }"></ContentControl>
                    </ControlTemplate>
                </ListView.Resources>-->
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <Canvas Background="White" />
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <!--<ListView.ItemContainerStyle>
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
                </ListView.ItemContainerStyle>-->
            </ItemsControl>
        </Grid>
        <StackPanel VerticalAlignment="Bottom" HorizontalAlignment="Stretch" Orientation="Horizontal">
            <ComboBox x:Name="Baseforms"></ComboBox>
            <ComboBox x:Name="CrystalGroups"></ComboBox>
        </StackPanel>
    </Grid>
