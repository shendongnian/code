    <xctk:SplitButton x:Name="btnSplit" Content="Select a product...">
        <xctk:SplitButton.DropDownContent>
            <ListBox ItemsSource="..."
                     SelectionChanged="ListBox_SelectionChanged">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding ProductName}" />
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </xctk:SplitButton.DropDownContent>
    </xctk:SplitButton>
    private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        ListBox content = (ListBox)sender;
        btnSplit.Content = ((DataRowView)content.SelectedItem)["ProductName"].ToString();
        btnSplit.IsOpen = false;
    }
