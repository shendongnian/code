        public CampaignContext()
            : base("con1")
        {
            Database.SetInitializer<CampaignContext>(new CampaignSeeder());
        }
