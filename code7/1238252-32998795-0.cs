        <TabControl Width="500">
            <TabControl.Items>
                <TabItem>
                    <TabItem.Header>
                        Prod
                    </TabItem.Header>
                    <TabItem.HeaderTemplate>
                        <DataTemplate>
                            <ContentPresenter Margin="-8, -3, -8, 0" >
                                <ContentPresenter.Content>
                                    <TextBlock MouseLeftButtonDown="prod_MouseLeftButtonDown" Text="{TemplateBinding Content}"/>
                                </ContentPresenter.Content>
                            </ContentPresenter>
                        </DataTemplate>
                    </TabItem.HeaderTemplate>
                </TabItem>
            </TabControl.Items>
        </TabControl>
