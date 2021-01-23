        <Window.Resources>
            <converter:WorkerToColorConverter x:Key="WorkerToColorConverter"/>
        </Window.Resources>
        <Grid>
            <DataGrid ItemsSource="{Binding WorkingItems}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Day" Binding="{Binding DateTime}"/>
                    <DataGridTextColumn Header="Worker" Binding="{Binding Worker}">
                        <DataGridTextColumn.ElementStyle>
                            <Style TargetType="{x:Type TextBlock}">
                                <Setter Property="Background" Value="{Binding Worker, Converter={StaticResource WorkerToColorConverter}}"/>
                            </Style>
                        </DataGridTextColumn.ElementStyle>
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
