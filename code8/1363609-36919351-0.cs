    public class ItemContainer
    {
        public ItemContainer()
        {           
            Collection = SetList(new[] { "1", "2", "3", "4" });
        }
        ObservableCollection<ItemDto> SetList(string[] result)
        {
            ObservableCollection<ItemDto> collection = new ObservableCollection<ItemDto>();
            foreach (string item in result)
            {
                collection.Add(GetDto(item));
            }
            return collection;
        }
        public ObservableCollection<ItemDto> Collection { get; set; }
        ItemDto GetDto(string item)
        {
            return new ItemDto() { MainPhotoSource = new Uri(_serverInbox + item) }; 
        }
    }
