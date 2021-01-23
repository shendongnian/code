    <Page x:Name="root">
        <Page.DataContext>
          <data:VM/>
        </Page.DataContext>
        <Page.Resources>
           <CollectionViewSource x:Key="cvs" IsSourceGrouped="True" 
                          Source="{Binding GroupedCollection, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                          ItemsPath="CredCategory"/>
        </Page.Resources>
        <Grid>
          <GridView x:Name="gridview" 
              ItemsSource="{Binding Source={StaticResource cvs}}"
              <GridView.ItemTemplate>
                 <DataTemplate>
                     <FlyoutBase.AttachedFlyout>
                       <MenuFlyout x:Name="flyout">
                          <MenuFlyoutItem Text="Delete" 
                               Command="{Binding DataContext.DeleteItem, ElementName=root}" 
                               CommandParameter="{Binding}"/>
                     </MenuFlyout>
                  </FlyoutBase.AttachedFlyout>                 
                <DataTemplate/>
            <GridView.ItemTemplate>
         <GridView/>
      <Grid/>
