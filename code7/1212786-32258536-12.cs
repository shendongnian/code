    <Window.DataContext>
      <viewModel:MainViewModel />
    </Window.DataContext>
    <Window.Resources>
      <local:EnumDescriptionConverter x:Key="EnumDescriptionConverter" />
      <local:EnumCheckedConverter x:Key="EnumCheckedConverter" />
    </Window.Resources>
    <TextBox Text="Right click me">
      <TextBox.ContextMenu>
        <ContextMenu ItemsSource="{Binding EnumChoiceProvider}">
          <ContextMenu.ItemTemplate>
            <DataTemplate>
              <MenuItem 
                IsCheckable="True"
                Width="150"
                Header="{Binding Path=., Converter={StaticResource EnumDescriptionConverter}}"
                Command="{Binding DataContext.ToggleEnumChoiceCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"
                CommandParameter="{Binding}">
                <MenuItem.IsChecked>
                  <MultiBinding Mode="OneWay" 
                                NotifyOnSourceUpdated="True" 
                                UpdateSourceTrigger="PropertyChanged" 
                                Converter="{StaticResource EnumCheckedConverter}">
                    <Binding Path="DataContext.SelectedEnumChoice" 
                             RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=Window}"  />
                    <Binding Path="."></Binding>
                  </MultiBinding>
                </MenuItem.IsChecked>    
              </MenuItem>
            </DataTemplate>
          </ContextMenu.ItemTemplate>
        </ContextMenu>
      </TextBox.ContextMenu>
    </TextBox>
