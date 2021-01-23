     <DockPanel >
            <TextBox DockPanel.Dock="Top" Text="{Binding FilterText, UpdateSourceTrigger=PropertyChanged}"></TextBox>
            <ListBox x:Name="list" ItemsSource="{Binding EmailsCollection}" SelectedItem="{Binding SelectedItem}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Grid >
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition />
                                <ColumnDefinition />
                            </Grid.ColumnDefinitions>
                            <Grid.RowDefinitions>
                                <RowDefinition />
                                <RowDefinition />
                            </Grid.RowDefinitions>
                            <Label Content="{Binding Sender}"  Name="SenderLabel" >
                                <Label.Style>
                                    <Style TargetType="Label">
                                        <Setter Property="FontWeight" Value="Normal"/>
                                        <Style.Triggers>                                            
                                            <DataTrigger Binding="{Binding IsRead}" Value="true">
                                                <Setter Property="FontWeight" Value="Bold"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Label.Style>
                                
                            </Label> 
                            <!--Style="{StaticResource Sender}"-->
                            <Label Grid.Row="1" Content="{Binding Subject}" FontSize="12" HorizontalAlignment="Left" />
                            <Label Grid.Column="1" Content="{Binding Date}" FontSize="12" HorizontalAlignment="Right" />
                        </Grid>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </DockPanel>
