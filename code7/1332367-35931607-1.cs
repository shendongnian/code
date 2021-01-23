    <Menu DockPanel.Dock="Top">
      <Menu.ItemTemplate>
        <HierarchicalDataTemplate DataType="{x:Type local:MenuItemViewModel}" ItemsSource="{Binding Path=MenuItems}">
          <TextBlock Text="{Binding}"/>
        </HierarchicalDataTemplate>
      </Menu.ItemTemplate>
      <Menu.ItemsSource>
        <CompositeCollection>
          <MenuItem Header="123" Style="{StaticResource NormalMenuItem}">
            <MenuItem Header="Beta1" Style="{StaticResource NormalMenuItem}"/>
            <MenuItem Header="Beta2"  Style="{StaticResource NormalMenuItem}"/>
            <MenuItem Header="Beta3"  Style="{StaticResource NormalMenuItem}"/>
            <MenuItem Header="Close" Command="Close" CommandTarget="{Binding ElementName=Window}" />
          </MenuItem>
          <CollectionContainer Collection="{Binding Source={StaticResource Items}}" />
        </CompositeCollection>
      </Menu.ItemsSource>
    </Menu>
