    public class RegisterViewModel
    {
        public static readonly IDictionary<string, string> VideoProviderDictionary = new Dictionary<string, string>
                {{"1", "Atlantic"},
                {"2", "Blue Ridge"}};
        public string VideoProvider { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
