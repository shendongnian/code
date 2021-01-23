    class SearchCriteria
    {
        public SearchCriteria()
        {
            this.Name = "adsfasd     ";
            this.Email = "       adsfasd     ";
            this.Company = "  asdf   adsfasd     ";
            this.stringMutators = ReflectionHelper.CreateMutators<SearchCriteria, String>(this);
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        // ... around 20 fields follow
        private IEnumerable<Action<Func<String, String>>> stringMutators;
        private String TrimMutate(String value)
        {
            if (String.IsNullOrEmpty(value))
                return value;
            return value.Trim();
        }
        public void Trim()
        {
            foreach (var mutator in this.stringMutators)
            {
                mutator(this.TrimMutate);
            }
        }
        public override string ToString()
        {
            return String.Format("Name = |{0}|, Email = |{1}|, Company = |{2}|",
                this.Name,
                this.Email,
                this.Company);
        }
    }
