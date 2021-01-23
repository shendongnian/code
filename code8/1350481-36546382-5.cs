    <ListBox ItemsSource="{Binding EmployeeList, IsAsync=True, UpdateSourceTrigger=Explicit}" SelectedItem="{Binding SelectedItem}">
    <cust:BListBox.ItemTemplate>
        <DataTemplate>
             <CheckBox IsChecked="{Binding IsChecked, UpdateSourceTrigger=Explicit}">
                 <CheckBox.Content>
                     <StackPanel Orientation="Horizontal">
                         <TextBlock Text="{Binding EmpName, IsAsync=True}" Visibility="Visible" />
                      </StackPanel>
                  </CheckBox.Content>
              </CheckBox>
        </DataTemplate>
    </ListBox.ItemTemplate>
