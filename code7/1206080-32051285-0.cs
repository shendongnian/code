    <Window.Resources>
        <DataTemplate x:Key="TreeTemplate">
            <Your TreeViewLayout ...>
        </DataTemplate>
    </Window.Resources>
    
    ...    
    <TabControl>
        <TabItem Header="Tab1">
            <Grid>
               <ContentControl Content = {"Binding"} ContentTemplate="{StaticResource TreeTemplate}" />   
            </Grid>
        </TabItem>
    
        <TabItem Header="Tab2">
            <Grid>
               <ContentControl Content = {"Binding"} ContentTemplate="{StaticResource TreeTemplate}" />     
            </Grid>
        </TabItem>
    </TabControl>
