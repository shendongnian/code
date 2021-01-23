    <TreeView ItemsSource="{Binding DataSource}">
        <TreeView.ItemContainerStyle>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TreeViewItem}">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="10" />
                                    <ColumnDefinition />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                    <RowDefinition Height="Auto" />
                                    <RowDefinition Height="Auto" />
                                </Grid.RowDefinitions>
                                <ToggleButton
                                    Name="ExpandButton"
                                    ClickMode="Press"
                                    IsChecked="{Binding Path=IsExpanded, RelativeSource={RelativeSource TemplatedParent}}"
                                    />
                                <ContentPresenter
                                    Grid.Column="1"
                                    ContentSource="Header"
                                    />
                                <TextBlock
                                    Name="Caption"
                                    Grid.Column="1"
                                    Grid.Row="1"
                                    Text="List Caption"
                                    />
                                <ItemsPresenter
                                    Name="Content"
                                    Grid.Column="1"
                                    Grid.Row="2"
                                    />
                                </Grid>
                                <ControlTemplate.Triggers>
                                <Trigger Property="IsExpanded" Value="False">
                                <Setter TargetName="Caption" Property="Visibility" Value="Collapsed" />
                                    <Setter TargetName="Content" Property="Visibility" Value="Collapsed" />
                                </Trigger>
                                <Trigger Property="HasItems" Value="False">
                                    <Setter TargetName="ExpandButton" Property="Visibility" Value="Collapsed" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.ItemContainerStyle>
    </TreeView>
