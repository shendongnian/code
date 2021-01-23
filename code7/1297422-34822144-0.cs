    ...
    xmlns:acb="clr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehavior"
    ...
    <ListBox ItemsSource="{Binding Target}"
             IsEnabled="{Binding IsControlEnabled}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <CheckBox Content="{Binding TitleName}"
                          IsChecked="{Binding IsChecked}">
                    <acb:CommandBehaviorCollection.Behaviors>
                        <acb:BehaviorBinding Event="Checked"
                                             Command="{Binding DataContext.SelectionChangedCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}"
                                             CommandParameter="{Binding}" />
                        <acb:BehaviorBinding Event="Unchecked"
                                             Command="{Binding DataContext.SelectionChangedCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}"
                                             CommandParameter="{Binding}" />
                    </acb:CommandBehaviorCollection.Behaviors>
                </CheckBox>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
