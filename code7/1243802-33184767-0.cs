    <ItemsControl ItemsSource="{Binding WordList}">
      <ItemsControl.ItemTemplate>
        <DataTemplate>
            <DataTemplate.Resources>
                <DiscreteObjectKeyFrame x:Key="proxy" Value="{Binding}"/>
            </DataTemplate.Resources>
            <ui:NewWord>
                <ui:NewWord.DataContext>
                    <viewModels:NewWordViewModel 
                                CorrespondingWord="{Binding Source={StaticResource proxy}}"/>
                </ui:NewWord.DataContext>
            </ui:NewWord>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
