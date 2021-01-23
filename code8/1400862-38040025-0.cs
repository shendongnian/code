    <Style TargetType="local:EnhancedListView">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:EnhancedListView">
                    <Grid HorizontalAlignment="Stretch">
                        <Grid.RowDefinitions>
                            <RowDefinition />
                            <RowDefinition />
                        </Grid.RowDefinitions>
                        <CheckBox Visibility="{Binding RelativeSource={RelativeSource TemplatedParent}, Converter={StaticResource BooleanToVisibilityConverter}, Path=IsCheckModeEnabled}" Grid.Column="0" />
                        <ListView Grid.Row="1" ItemsSource="{TemplateBinding ItemsSource}" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Style TargetType="local:EnhancedListViewDataItem">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:EnhancedListViewDataItem">
                    <Grid HorizontalAlignment="Stretch">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <CheckBox Visibility="{Binding RelativeSource={RelativeSource TemplatedParent}, Converter={StaticResource BooleanToVisibilityConverter}, Path=IsCheckModeEnabled}" Grid.Column="0" />
                        <TextBlock Text="{Binding}" Grid.Column="1" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
