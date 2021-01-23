    public ConcreteSectionWorkerService : SectionWorker<SomeDomainModel>
    {
        protected override IRepository<SomeDomainModel> Repository { get; private set; }
    
        public ConcreteSectionWorkerService()
        {
            Repository = new WhatEverRepository(); //carefull you have to set this...
        }
        ....
    }
