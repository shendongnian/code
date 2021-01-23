    <DataGrid x:Name="dgTest" HorizontalAlignment="Left" AutoGenerateColumns="False" Margin="37,152,0,0" VerticalAlignment="Top" Height="126" Width="440" ItemsSource="{Binding XPath=data/Limits}" SelectionChanged="dgTest_SelectionChanged">
                <DataGrid.Resources>
                    <DataTemplate x:Key="CustomDetailTemplate">
                        <StackPanel>
                            <ComboBox SelectionChanged="ComboBox_SelectionChanged_1" Loaded="ComboBox_Loaded_2" >
                                <ComboBoxItem>Aucune</ComboBoxItem>
                                <ComboBoxItem>Légère</ComboBoxItem>
                                <ComboBoxItem>Modérée</ComboBoxItem>
                                <ComboBoxItem>Forte</ComboBoxItem>
                                <ComboBoxItem>Totale</ComboBoxItem>
                            </ComboBox>
                        </StackPanel>
                    </DataTemplate>
    
                    <DataTemplate x:Key="CustomLimitationTemplate">
                        <StackPanel>
                            <ComboBox SelectionChanged="ComboBox_SelectionChanged_2" Loaded="ComboBox_Loaded_1" > 
                                <ComboBoxItem>01</ComboBoxItem>
                                <ComboBoxItem>02</ComboBoxItem>
                                <ComboBoxItem>03</ComboBoxItem>
                                <ComboBoxItem>04</ComboBoxItem>
                                <ComboBoxItem>05</ComboBoxItem>
                            </ComboBox>
                        </StackPanel>
                    </DataTemplate>
                    <DataTemplate x:Key="CustomCapacityTemplate">
                        <StackPanel>
                            <ComboBox Loaded="ComboBox_Loaded_3" >
                                <ComboBoxItem>11</ComboBoxItem>
                                <ComboBoxItem>12</ComboBoxItem>
                                <ComboBoxItem>13</ComboBoxItem>
                                <ComboBoxItem>14</ComboBoxItem>
                                <ComboBoxItem>15</ComboBoxItem>
                            </ComboBox>
                        </StackPanel>
                    </DataTemplate>
                </DataGrid.Resources>
                <DataGrid.Columns>
                    <DataGridTextColumn Header="ID" x:Name="IdColumn" Binding="{Binding XPath=Id}" />
                    <DataGridTemplateColumn Header="Capacite" CellTemplate="{StaticResource CustomCapacityTemplate}" Width="100" />
                    <DataGridTemplateColumn Header="Limitation" x:Name="LimitationColumn" CellTemplate="{StaticResource CustomLimitationTemplate}" Width="150" />
                    <DataGridTemplateColumn Header="Aide" CellTemplate="{StaticResource CustomDetailTemplate}" Width="97" />
                </DataGrid.Columns>
            </DataGrid>
