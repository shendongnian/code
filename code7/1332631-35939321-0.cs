    interface ISearch
    {
        string Key { get; set; }
        Task<IEnumerable<TopicViewModels>> Search();
    }
    class MyViewModel : ISearch
    {
        [Required(ErrorMessage = "Search key must be required.")]
        public string Key { get; set; }
        public Task<IEnumerable<TopicViewModels>> Search()
        {
        }
    }
