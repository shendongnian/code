    <ItemsControl ItemsSource="{Binding}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="{x:Type ContentPresenter}">
                <Setter Property="Grid.Row" Value="{Binding Row}"/>
                <Setter Property="Grid.Column" Value="{Binding Col}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="0.1*"/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <TextBlock Text="{Binding Title}" VerticalAlignment="Bottom" HorizontalAlignment="Center" Grid.Row="0" FontWeight="Bold" TextDecorations="Underline"/>
                    <ListView ItemsSource="{Binding Names}" Grid.Row="1"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
