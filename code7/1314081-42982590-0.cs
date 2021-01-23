     <ListView x:Name="lvJobs" HorizontalAlignment="Left" Height="628" Margin="30,62,0,0" ItemsSource="{Binding Jobs}" 
                      SelectedItem="{Binding SelectedJob, Mode=TwoWay}" VerticalAlignment="Top" Width="335">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Active" Width="50">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <CheckBox IsChecked="{Binding IsActive, Mode=TwoWay}"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Job Name" Width="150">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBox Text="{Binding JobName, Mode=TwoWay}" BorderThickness="0" Background="Transparent"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn DisplayMemberBinding="{Binding User}" Header="User" Width="125"/>
                    </GridView>
                </ListView.View>
            </ListView>
