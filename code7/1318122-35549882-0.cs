    <Window x:Class="MvvmNavigationIssue.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mvvmNavigationIssue="clr-namespace:MvvmNavigationIssue"
        Title="MainWindow" Height="350" Width="525" x:Name="This">
    <Window.DataContext>
        <mvvmNavigationIssue:MainNavigationViewModel/>
    </Window.DataContext>
    <Window.Resources>
        <mvvmNavigationIssue:FreezableProxyClass x:Key="ProxyElement" 
                                                 ProxiedDataContext="{Binding Source={x:Reference This}, Path=DataContext}"/>
        <DataTemplate x:Key="DefaultDataTemplate">
            <Grid>
                <Rectangle HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Fill="Tomato" />
                <TextBlock Text="Default Template" HorizontalAlignment="Center" VerticalAlignment="Center"></TextBlock>
            </Grid>
        </DataTemplate>
        <DataTemplate x:Key="JobsDataTemplate">
            <ListView ItemsSource="{Binding JobModels, UpdateSourceTrigger=PropertyChanged}">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Id" DisplayMemberBinding="{Binding Id, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate DataType="mvvmNavigationIssue:JobModel">
                                    <TextBlock Text="{Binding Id}"></TextBlock>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Title" DisplayMemberBinding="{Binding Title, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
                        <GridViewColumn Header="Salary" DisplayMemberBinding="{Binding Salary, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
                        <GridViewColumn Header="" Width="100">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate DataType="mvvmNavigationIssue:JobModel">
                                    <Button Command="{Binding Source={StaticResource ProxyElement}, 
                                        Path=ProxiedDataContext.ShowLogsCommand, Mode=OneWay, 
                                        UpdateSourceTrigger=PropertyChanged}" CommandParameter="{Binding }">Logs</Button>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
        </DataTemplate>
        <DataTemplate x:Key="LogsDataTemplate">
            <ListView ItemsSource="{Binding LogModels, UpdateSourceTrigger=PropertyChanged}">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Id" DisplayMemberBinding="{Binding Id, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate DataType="mvvmNavigationIssue:JobModel">
                                    <TextBlock Text="{Binding Id}"></TextBlock>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Title" DisplayMemberBinding="{Binding Title, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
                        <GridViewColumn Header="Time" DisplayMemberBinding="{Binding LogTime, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
                        <GridViewColumn Header="Event" DisplayMemberBinding="{Binding LogEvent, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
                        <GridViewColumn Header="" Width="100">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate DataType="mvvmNavigationIssue:JobModel">
                                    <Button Command="{Binding Source={StaticResource ProxyElement}, 
                                        Path=ProxiedDataContext.ShowAllJobsCommand, Mode=OneWay, 
                                        UpdateSourceTrigger=PropertyChanged}">All Jobs</Button>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
        </DataTemplate>
        <mvvmNavigationIssue:MainContentTemplateSelector x:Key="MainContentTemplateSelectorKey" 
                                                         DefaultDataTemplate="{StaticResource DefaultDataTemplate}"
                                                         JobsViewDataTemplate="{StaticResource JobsDataTemplate}"
                                                         LogsViewDataTemplate="{StaticResource LogsDataTemplate}"/>
    </Window.Resources>
    <Grid>
        <ContentControl Content="{Binding CurrentViewModel, UpdateSourceTrigger=PropertyChanged}"
                        ContentTemplateSelector="{StaticResource MainContentTemplateSelectorKey}"></ContentControl>
    </Grid>
