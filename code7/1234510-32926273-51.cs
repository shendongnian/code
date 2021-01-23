    ...
    xmlns:interactivity="using:Microsoft.Xaml.Interactivity"
    xmlns:core="using:Microsoft.Xaml.Interactions.Core"
    ...
   
    <Grid>
        <ListView ItemsSource="{Binding Source}" IsItemClickEnabled="True" Margin="20">
            <interactivity:Interaction.Behaviors>
                <core:EventTriggerBehavior EventName="ItemClick">
                    <core:InvokeCommandAction 
                        Command="{Binding BCommand}" 
                        InputConverter="{StaticResource ItemClickedToMySourceConverter}" />
                </core:EventTriggerBehavior>
            </interactivity:Interaction.Behaviors>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding A}" />
                        <TextBlock Text="{Binding B}" />
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
