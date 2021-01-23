    <UserControl.Resources>
        <b:TextFilter x:Key="SearchTextFilter" />
        <CollectionViewSource Source="{Binding ListOfStuff}"  x:Key="FilteredListOfStuff">
            <i:Interaction.Behaviors>
                <b:FilterBehavior>
                    <b:PropertyFilter Property="SomePropName">
                        <StaticResource ResourceKey="SearchTextFilter"/>
                    </b:PropertyFilter>
                </b:FilterBehavior>
            </i:Interaction.Behaviors>
        </CollectionViewSource>
    </UserControl.Resources>
    .
    .
    .
    <TextBox Text="{Binding Path=FilterText, Source={StaticResource SearchTextFilter}, Mode=OneWayToSource}"/>
