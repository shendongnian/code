    <Expander Header="{Binding SelectedTitle}" Grid.Row="3" Grid.ColumnSpan="2">
     <StackPanel >
          <CheckBox IsChecked="{Binding Path=SelectedItem.isTest1, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">Test 1</CheckBox>
          <CheckBox IsChecked="{Binding Path=SelectedItem.isTest2, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">Test 2</CheckBox>
          <CheckBox IsChecked="{Binding Path=SelectedItem.isTest3, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">Test 3</CheckBox>
     </StackPanel>
