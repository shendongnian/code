     <Window.DataContext>
            <local:MainViewModel/>
        </Window.DataContext>
        
        <Grid Height="200">
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <ContentControl Content="{Binding SelectedViewModel, UpdateSourceTrigger=PropertyChanged}">
                <ContentControl.Resources>
                    <DataTemplate DataType="{x:Type local:ReadViewModel}">
                        <StackPanel>
                            <Button Content="Say Hello world" Command="{Binding HelloCommand}"></Button>
                        </StackPanel>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type local:WriteViewModel}">
                        <StackPanel>
                            <Button Content="Say Hello world" Command="{Binding HelloCommand}"></Button>
                            <Button Content="Say Hello Moon" Command="{Binding HelloMoonCommand}"></Button>
                        </StackPanel>
                    </DataTemplate>
                </ContentControl.Resources>
            </ContentControl>
            <Button Content="Switch VM" Command="{Binding SwitchViewModelCommand}" Grid.Row="1"/>
        </Grid>
