    <Grid MaxHeight="200" d:LayoutOverrides="Width">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="80*"/>
        <ColumnDefinition Width="20*"/>
    </Grid.ColumnDefinitions>
    <ListBox Height="170" ScrollViewer.HorizontalScrollBarVisibility="Visible" ItemsSource="{Binding DataModel.LocalData.ListFabricRules}" IsEnabled="{Binding DataModel.LocalData.Enabled}" SelectedItem="{Binding DataModel.LocalData.ListFabricRulesSelected}" >
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <TextBlock Text="{Binding Descript}" />
                </Grid>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    <StackPanel Grid.Column="1" Orientation="Vertical" d:LayoutOverrides="Height" Margin="10,0" IsEnabled="{Binding DataModel.LocalData.EnabledRules}">
        <Button Content="Test" />
    </StackPanel>
