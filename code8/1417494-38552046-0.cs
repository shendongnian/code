    class ViewModel
    {
        public ObservableCollection<Models.Country> Country { get; }
        public IEnumerable<League> AllLeagues => Country.SelectMany(c => c.Leagues);
    }
    public class League
    {
        public string Name { get; set; }
        public List<Event> Event { get; set; }
        // add Country here
        public Country Country { get; set; }
    }
    class 
    <CollectionViewSource Source="{Binding AllLeagues}" x:Key="GroupedItems">
       <CollectionViewSource.GroupDescriptions>
            <PropertyGroupDescription PropertyName="Country" />
       </CollectionViewSource.GroupDescriptions>
