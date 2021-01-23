    <TabControl>
        <TabItem Header="TabItem">
            <Label Content="{Binding Path=myString}"/>
        </TabItem>
        <TabItem Header="TabItem" Content="{Binding Path=myString}">
            <TabItem.ContentTemplate>
                <DataTemplate>
                    <Label Content="{Binding}" />
                </DataTemplate>
            </TabItem.ContentTemplate>
        </TabItem>
    </TabControl>
