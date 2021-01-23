        public async Task<CompanyBoardViewModel> GetIndexViewModel(IEnumerable<int> parameter, bool isMore = false, bool currentRole = false)
            {
                    return new CompanyBoardViewModel
                    {
                        TopJoinAplicant = this.TopJointApplicant(parameter, isMore),
                        TopPriorityCountry = await this.TopPriorityCountry(parameter),
                        TopPublicationCountries = await this.TopPublicationCountries(parameter),
                        TopGrantedInventors = await this.TopGrantedInventors(parameter),
                        TopIPC = await this.TopIPC(parameter),
                        TopCPC = await this.TopCPC(parameter),
                        TopCitedInventors = await this.TopCitedInventors(parameter),
                        TopCitedPatents = await this.TopCitedPatents(parameter),
                        CGAR = await this.GetCGAR(parameter),
                    };
        }
        private QuantTableViewModel<TopFilterViewModel> TopJointApplicant(IEnumerable<int> ids, bool isMore = false)
                {
                    var Data = this.cache.TopJointApplicant(ids).ToList();
                    return new QuantTableViewModel<TopFilterViewModel>
                    {
                        Tableid = "TopJointApplicants",
                        Title = "Top Joint Applicants",
                        FirstCol = "Position",
                        SecondCol = "Joint Applicant",
                        ThirdCol = "#",
                        IsSeeMore = isMore,
                        Data = this.cache.TopJointApplicant(ids).ToList()
                    });
                }
