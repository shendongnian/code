    public class MainWindowViewModel
    {
        public ObservableCollection<Rat> Rats { get; set; } =
            new ObservableCollection<Rat>()
            {
                new Rat()
                {
                    Name = "Fred",
                    Age = "19",
                    Sex = SexEnum.Male
                },
                new Rat()
                {
                    Name = "Martha",
                    Age = "21",
                    Sex = SexEnum.Female
                }
            };
    }
