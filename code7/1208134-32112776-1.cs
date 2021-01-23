    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition Width="3*"/>
        </Grid.ColumnDefinitions>
        <ComboBox x:Name="ComboBoxMenu" Grid.Column="0" Margin="5" Height="20" ItemsSource="{Binding Settings}" SelectedIndex="0">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}" Padding="10"/>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
        <Border Grid.Column="1" Margin="5" BorderBrush="#FF7F9DB9" BorderThickness="1">
            <ContentControl Content="{Binding ElementName=ComboBoxMenu, Path=SelectedItem}"/>
        </Border>
    </Grid>
