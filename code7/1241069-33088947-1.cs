    <Window.DataContext>
      <data:ViewModel/>
    </Window.DataContext>
    <Window.InputBindings>
      <KeyBinding Command="{Binding AddCommand}">
        <KeyBinding.Gesture>
          <KeyGesture>Ctrl+N</KeyGesture>
        </KeyBinding.Gesture>
      </KeyBinding>
      <KeyBinding Command="{Binding RemoveCommand}"
                  CommandParameter="{Binding SelectedItem, ElementName=tabControl1}">
        <KeyBinding.Gesture>
          <KeyGesture>Ctrl+W</KeyGesture>
        </KeyBinding.Gesture>
      </KeyBinding>
    </Window.InputBindings>
  
    <Grid>
      <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
      </Grid.RowDefinitions>
      <TabControl x:Name="tabControl1" ItemsSource="{Binding TabItems}" Grid.Row="1" Background="LightBlue">
        <TabControl.ItemTemplate>
          <DataTemplate>
            <StackPanel Orientation="Horizontal" VerticalAlignment="Center">
              <TextBlock Text="{Binding Header}" VerticalAlignment="Center"/>
              <Button Content="x" Width="20" Height="20" Margin="5 0 0 0"
                      Command="{Binding DataContext.RemoveCommand, RelativeSource={RelativeSource AncestorType=TabControl}}"
                      CommandParameter="{Binding DataContext, RelativeSource={RelativeSource Self}}">
              </Button>
            </StackPanel>
          </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
          <DataTemplate>
            <TextBlock Text="{Binding Content}" />
          </DataTemplate>
        </TabControl.ContentTemplate>
      </TabControl>
    </Grid>
