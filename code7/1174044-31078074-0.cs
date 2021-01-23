    <TabControl ItemsSource="{Binding Collection}"
                ContentTemplateSelector="{DynamicResource MyContentTemplateSelector}">
        <TabControl.Resource>
            <DataTemplate x:Key="BetaTemplate" DataType="{x:Type viewModels:SubViewModelAlpha}">
                <TextBlock>SubViewModelAlpha</TextBlock>
            </DataTemplate>
            <DataTemplate x:Key="BetaTemplate" DataType="{x:Type viewModels:SubViewModelBeta}">
                <TextBlock>SubViewModelBeta</TextBlock>
            </DataTemplate>
            <viewModels:MyContentTemplateSelector
                x:Key="MyContentTemplateSelector" 
                AlphaTemplate="{StaticResource AlphaTemplate}"
                BetaTemplate="{StaticResource BetaTemplate}" />
        <TabControl.Resource>
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Title}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
