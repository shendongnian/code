    <Window x:Class="WpfApplication1.View.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:viewModel="clr-namespace:WpfApplication1.ViewModel"
            xmlns:local="clr-namespace:WpfApplication1"
            Title="MainWindow"
            Height="300"
            Width="250">
        <!-- Set data context -->        
        <Window.DataContext>
          <viewModel:MainViewModel />
        </Window.DataContext>
        <!-- Converters -->
        <Window.Resources>
          <local:EnumDescriptionConverter x:Key="EnumDescriptionConverter" />
          <local:EnumCheckedConverter x:Key="EnumCheckedConverter" />
        </Window.Resources>
        <!-- Element -->    
        <TextBox Text="Right click me">
          <!-- Context menu -->
          <TextBox.ContextMenu>
            <ContextMenu ItemsSource="{Binding EnumChoiceProvider}">
              <ContextMenu.ItemTemplate>
                <DataTemplate>
                  <!-- Menu item header bound to enum converter -->
                  <!-- IsChecked bound to current selection -->
                  <!-- Toggle bound to a command, setting current selection -->
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
                                 RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}"  />
                        <Binding Path="."></Binding>
                      </MultiBinding>
                    </MenuItem.IsChecked>    
                  </MenuItem>
                </DataTemplate>
              </ContextMenu.ItemTemplate>
            </ContextMenu>
          </TextBox.ContextMenu>
        </TextBox>
    </Window>
