    <TabControl>
        <TabItem Header="TabItem">
            <Label Content="{Binding Path=Value2}"/>
        </TabItem>
        <TabItem Header="TabItem" Content="{Binding Path=Value2}">
            <TabItem.ContentTemplate>
                <DataTemplate>
                    <Label Content="{Binding}" />
                </DataTemplate>
            </TabItem.ContentTemplate>
        </TabItem>
    </TabControl>
