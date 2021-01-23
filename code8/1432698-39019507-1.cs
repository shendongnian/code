     public ActionResult Index()
        {
            var vm = new Application();
            vm.Applications = new List<CardType>
           {
               new CardType {Value = "DebitOnly", Name = "Card 1" },
               new CardType {Value = "CreditAndDebit", Name = "Card 2" },
               new CardType {Value = "DebitOnly", Name = "Card 3" },
               new CardType {Value = "CreditAndDebit", Name = "Card 4" },
               new CardType {Value = "Neither", Name = "Card 5" },
               new CardType {Value = "DebitOnly", Name = "Card 6" },
               new CardType {Value = "Neither", Name = "Card 7" },
           };
            return View(vm);
        }
