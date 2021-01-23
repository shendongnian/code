    <Hub Header="{Binding HubHeader}" >
        <HubSection Header="{Binding NewestOffersHeader}" IsHeaderInteractive="True" >
            <DataTemplate >
                <local:NewestOffersView  DataContext="{Binding NewestOffersViewModel}" />
            </DataTemplate>
        </HubSection>
        <HubSection Header="{Binding SearchHeader}" IsHeaderInteractive="True" >
            <DataTemplate x:Name="SearchView">
                <local:SearchView DataContext="{Binding SearchViewModel}"/>
            </DataTemplate>
        </HubSection>
        <HubSection Header="{Binding AddOfferHeader}" IsHeaderInteractive="True" >
            <DataTemplate>
                <local:AddOfferView DataContext="{Binding AddOfferViewModel}"/>
            </DataTemplate>
        </HubSection>
        <HubSection Header="{Binding AccountHeader}" IsHeaderInteractive="True">
            <DataTemplate>
                <local:AccountView DataContext="{Binding AccountViewModel}"/>
            </DataTemplate>
        </HubSection>
    </Hub>
