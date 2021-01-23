    <Window x:Class="SoButtonBindingHelpAttempt.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:soButtonBindingHelpAttempt="clr-namespace:SoButtonBindingHelpAttempt"
        Title="MainWindow" Height="350" Width="525">
    <Window.DataContext>
        <soButtonBindingHelpAttempt:MainViewModel/>
    </Window.DataContext>
    <Grid>
        <ListBox ItemsSource="{Binding ObservableCollection}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                    <Setter Property="ContentTemplate">
                        <Setter.Value>
                            <DataTemplate DataType="{x:Type soButtonBindingHelpAttempt:Empclass}">
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="120"></ColumnDefinition>
                                        <ColumnDefinition Width="120"></ColumnDefinition>
                                        <ColumnDefinition Width="120"></ColumnDefinition>
                                    </Grid.ColumnDefinitions>
                                    <TextBlock Grid.Column="0" Text="{Binding abc, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"></TextBlock>
                                    <TextBlock Grid.Column="1"  Text="{Binding pqr, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"></TextBlock>
                                    <Button    Grid.Column="2"  Command="{Binding Command}" Content="Press me!"></Button>
                                </Grid>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>
    </Grid></Window>
