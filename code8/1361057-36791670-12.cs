    public async Task<CompanyBoardViewModel> GetIndexViewModel(IEnumerable<int> parameter, bool isMore = false, bool currentRole = false)
    {
        // Let the threads start processing.
        var topApplicantTask = this.TopJointApplicant(parameter, isMore);
        var topPriorityCountryTask = this.TopPriorityCountry(parameter);
        var topPublicationContriesTask = this.TopPublicationCountries(parameter);
        var topIPCTask = this.TopIPC(parameter);
        var topCPCTask = this.TopCPC(parameter);
        var topCitedInventorsTask = this.TopCitedInventors(parameter);
        var topCitetPatentsTask = this.TopCitedPatents(parameter);
        var getCGARTask = this.GetCGAR(parameter);
        // Await them later.
        return new CompanyBoardViewModel
        {
            TopJoinAplicant = await topApplicantTask,
            TopPriorityCountry = await topPriorityCountryTask,
            TopPublicationCountries = await topPublicationContriesTask,
            TopGrantedInventors = await this.TopGrantedInventors(parameter),
            TopIPC = await topIPCTask,
            TopCPC = await topCPCTask,
            TopCitedInventors = await topCitedInventorsTask,
            TopCitedPatents = await topCitetPatentsTask,
            CGAR = await getCGARTask,
         };
    }
