    <UserControl
     ...the code omitted for the brevity...
      xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
      xmlns:ei="http://schemas.microsoft.com/expression/2010/interactions"
    ...the code omitted for the brevity...
    >
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="5*"/>
        </Grid.ColumnDefinitions>             
       <ListView ItemsSource="{Binding Persons}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDoubleClick">
                    <ei:CallMethodAction MethodName="DoubleClickMethod" TargetObject="{Binding}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding IdPerson}" Margin="0,0,5,0"/>
                        <TextBlock Text="{Binding Name}"/>
                    </StackPanel>
                </DataTemplate>                
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
    </UserControl>
