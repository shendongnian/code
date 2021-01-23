        <TabControl.ContentTemplate>
            <DataTemplate DataType="{x:Type namespace:MembersViewModel}">
                <namespace:MembersView />
            </DataTemplate>
        </TabControl.ContentTemplate>
    (Replace "namespace:" with your xaml imported namespace containing your controls.)
