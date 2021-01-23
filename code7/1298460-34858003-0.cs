    <Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"></RowDefinition>
        <RowDefinition Height="Auto"></RowDefinition>
    </Grid.RowDefinitions>
    <ListView ItemsSource="{Binding Items}">
        <ListView.View>
            <GridView>
                <GridViewColumn>
                    <GridViewColumn.CellTemplate >
                        <DataTemplate >
                            <StackPanel Orientation="Horizontal" HorizontalAlignment="Left" VerticalAlignment="Center" >
                                <CheckBox VerticalAlignment="Center" Margin="0,0,0,0" Content="{Binding Name}" IsChecked="{Binding IsSelected}"  />
                            </StackPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
    <Button Grid.Row="1" Content="What is checked?" Command="{Binding GoCommand}"></Button>
