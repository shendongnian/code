        public PagedResult<Violation> GetViolationByModule(PagedRequest pagedRequest, long moduleId, long stakeHolderId, Expression<Func<Violation, bool>> filter, string sort = "")
        {
            return ExceptionManager.Process(() => _GetViolationByModule(pagedRequest, moduleId, stakeHolderId, filter, sort),
             "ServicePolicy");
        }
        private PagedResult<Violation> _GetViolationByModule(PagedRequest pagedRequest, long moduleId, long stakeHolderId, Expression<Func<Violation, bool>> filter, string sort = "")
        {
            var query = ViolationRepository.GetViolationByModule(moduleId, stakeHolderId);
            
            if(!string.IsNullOrEmpty(sort))
            {
                string sortProperty = string.Empty;
                bool desc = false;
                if(sort.TryParseSortText(out sortProperty, out desc))
                {
                    query = query.OrderBy(sortProperty, desc);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            var violations = _GetPagedResult(pagedRequest, query);
            foreach (var violation in violations.Results)
            {
                var user = FrontendUserRepository.GetFrontendUserByName(violation.ReportBy);
                if (user != null)
                {
                    violation.ReportUserInitial = user.Initial;
                }
                else
                {
                    violation.ReportUserInitial = violation.ReportBy;
                }
            }
            return violations;
        }
