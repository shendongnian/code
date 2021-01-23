        <ListBox Name="MyListBox" MouseDoubleClick="Open_Click">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal" >
                        <TextBlock Text="{Binding}" />
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        void Open_Click(object sender, EventArgs e) {
            ListBox listbox = sender as ListBox;
            string filename = listbox.SelectedItem.ToString();
        }
