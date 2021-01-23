    <UserControl.Resources>
        <CollectionViewSource Source="{Binding DS.AllRem}" x:Key="RemViewSource" IsLiveSortingRequested="True" >
            <CollectionViewSource.SortDescriptions>
                <componentModel:SortDescription PropertyName="ReminderDataTime" Direction="Descending"/>
            </CollectionViewSource.SortDescriptions>
        </CollectionViewSource>
    </UserControl.Resources>   
