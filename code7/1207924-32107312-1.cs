    <ComboBox ItemsSource="{Binding Colors}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="auto" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Rectangle Grid.Column="0" Height="30" Width="30" Margin="2" VerticalAlignment="Center" Stroke="{ThemeResource SystemControlForegroundBaseHighBrush }" StrokeThickness="1">
                        <Rectangle.Fill>
                            <SolidColorBrush Color="{Binding Color}" />
                        </Rectangle.Fill>
                    </Rectangle>
                    <TextBlock Text="{Binding Name}" Grid.Column="1" VerticalAlignment="Center"/>
                </Grid>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
