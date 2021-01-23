    <Window.DataContext>
        <local:MainViewModel />
    </Window.DataContext>
    <StackPanel>
        <!--Bind to Text and IsEnabled properties in ViewModel-->
        <TextBox Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}" 
                 IsEnabled="{Binding IsEnabled}">
        </TextBox>
        <!--Bind to IsEnabled property in ViewModel-->
        <CheckBox Content="Text input enabled" 
                  IsChecked="{Binding IsEnabled}">
        </CheckBox>
        <!--Bind to SaveCommand in ViewModel-->
        <Button Content="Save" 
                Command="{Binding SaveCommand}">
        </Button>
    </StackPanel>
