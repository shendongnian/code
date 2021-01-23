    <ListBox Name="EmpList" ItemsSource="{Binding empList.Values, IsAsync=True, UpdateSourceTrigger=Explicit}">
        <cust:BListBox.ItemTemplate>
            <DataTemplate>
                 <CheckBox IsChecked="{Binding isChecked, UpdateSourceTrigger=Explicit}">
                     <CheckBox.Content>
                         <StackPanel Orientation="Horizontal">
                             <TextBlock Text="{Binding empName, IsAsync=True}" Visibility="Visible" />
                          </StackPanel>
                      </CheckBox.Content>
                  </CheckBox>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    <Button Content="Apply" behaviors:ApplyAllCheckBoxBindingsInListBoxBehavior.ListBox="{Binding ElementName=EmpList}"/>
