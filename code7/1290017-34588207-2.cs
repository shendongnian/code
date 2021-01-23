    <Window.DataContext>
        <local:MainViewModel />
    </Window.DataContext>
    <StackPanel>
        <TextBox Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}" 
                 IsEnabled="{Binding IsEnabled}">
        </TextBox>
        <CheckBox Content="Text input enabled" 
                  IsChecked="{Binding IsEnabled}">
        </CheckBox>
        <Button Content="Save" 
                Command="{Binding SaveCommand}">
        </Button>
    </StackPanel>
