    <Window.Resources>
        <DataTemplate x:Key="TreeTemplate">
            <Your TreeViewLayout ...>
        </DataTemplate>
    </Window.Resources>
    
    ...    
    <TabControl>
        <TabItem Header="Tab1">
           <ContentControl Content="{Binding}" ContentTemplate="{StaticResource TreeTemplate}" />   
        </TabItem>
    
        <TabItem Header="Tab2">
            <ContentControl Content="{Binding}" ContentTemplate="{StaticResource TreeTemplate}" />     
        </TabItem>
    </TabControl>
