    <Page.Resources>
            <local:BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
    </Page.Resources>
     <ComboBox x:Name="cbState" DropDownClosed="cbState_DropDownClosed" DropDownOpened="cbState_DropDownOpened"  Margin="75,287,0,0" Width="169" ItemContainerStyle="{StaticResource ComboBoxItemStyle1}" Style="{StaticResource ComboBoxStyle1}"   >
                
                    <ComboBox.ItemTemplate>
                        <DataTemplate>
                        <StackPanel>
                            <CheckBox Content="{Binding}" 
                                       Visibility="{Binding IsCheckBoxVisible, Mode=TwoWay, Converter={StaticResource BooleanToVisibilityConverter}, UpdateSourceTrigger=PropertyChanged}" >
                                </CheckBox>
                            <TextBlock Text="{Binding State_Name}"/>
                        </StackPanel>
                    </DataTemplate>
                    </ComboBox.ItemTemplate>
    
                </ComboBox>
    
       private void cbState_DropDownClosed(object sender, object e)
            {
                foreach (var item in (sender as ComboBox).Items)
                {
                    (item as State).IsCheckBoxVisible = false;
                }
            }
    
            private void cbState_DropDownOpened(object sender, object e)
            {
                foreach(var item in (sender as ComboBox).Items)
                {
                    (item as State).IsCheckBoxVisible = true;
                }
            }
      
