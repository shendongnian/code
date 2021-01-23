    <DataTrigger Binding="{Binding IsAnimationEnabled}" Value="True">
        <DataTrigger.EnterActions>
            <BeginStoryboard x:Name="MyStoryBoard" Storyboard="{StaticResource MyStoryBoardResourceKey}"/>
        </DataTrigger.EnterActions>
        <DataTrigger.ExitActions>
            <RemoveStoryboard BeginStoryboardName="MyStoryBoard"/>
        </DataTrigger.ExitActions>
    </DataTrigger>
