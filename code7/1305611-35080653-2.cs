    <Window x:Class="LocalizationSimple.MainWindow"
            ...the code omitted for the brevity
            xmlns:vm="clr-namespace:LocalizationSimple.ViewModel"
            Title="a" Height="350" Width="525" WindowStartupLocation="CenterScreen">
        <Window.DataContext>
            <vm:MainWindowVM/>
        </Window.DataContext>
        <Grid>
            <StackPanel>
                <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Persons}" >
                    <DataGrid.Columns>
                        <DataGridTextColumn Binding="{Binding Name}" />
    
                        <DataGridComboBoxColumn Header="CourtType"
                                                DisplayMemberPath="NameTeam" SelectedValueBinding="{Binding MyProperty}" SelectedValuePath="{Binding MyProperty }"
                                                >
                            <DataGridComboBoxColumn.ElementStyle>
                                <Style TargetType="ComboBox">
                                    <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Path=DataContext.Teams}"/>
                                    <Setter Property="IsReadOnly" Value="True"/>
                                </Style>
                            </DataGridComboBoxColumn.ElementStyle>
                            <DataGridComboBoxColumn.EditingElementStyle>
                                <Style TargetType="ComboBox">
                                    <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Path=DataContext.Teams}"/>
                                </Style>
                            </DataGridComboBoxColumn.EditingElementStyle>
                        </DataGridComboBoxColumn>
    
                        <DataGridTextColumn Binding="{Binding Name}"/>
                    </DataGrid.Columns>                
                </DataGrid>
            </StackPanel>
        </Grid>
    </Window>
