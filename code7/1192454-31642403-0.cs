        public class ViewModel
        {
            public ViewModel()
            {
                Names = new Dictionary<string, string>()
                {
                    { "4EG25","John" },
                    {"923OT", "Joe" }
                };
                EnabledNames = new Dictionary<string, bool>()
                {
                    { "4EG25",false },
                    {"923OT", true}
                };
            }
            public Dictionary<string, string> Names { get; set; }
            public Dictionary<string, bool> EnabledNames { get; set; }
        }
