    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        
        <DataGrid x:Name="ItemsGrid" AutoGenerateColumns="False" ItemsSource="{Binding Items}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="Group" Binding="{Binding Group.Name}"/>
            </DataGrid.Columns>
        </DataGrid>
        <ContentControl Grid.Column="1" Content="{Binding SelectedItem, ElementName=ItemsGrid}">
            <ContentControl.ContentTemplate>
                <DataTemplate>
                    <ComboBox Height="20" ItemsSource="{Binding Groups}" SelectedItem="{Binding Group}">
                        <ComboBox.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Name}"/>
                            </DataTemplate>
                        </ComboBox.ItemTemplate>
                    </ComboBox>
                </DataTemplate>
            </ContentControl.ContentTemplate>
        </ContentControl>
    </Grid>
