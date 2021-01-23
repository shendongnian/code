    public List<FileConversion> GetConversionsForDataTables(String sSearch, int iDisplayStart, int iDisplayLength, Func<FileConversion, string> sort, bool asc)
        {
            System.Linq.Expressions.Expression<Func<FileConversion, bool>> predicate = GetPredicateForFileConversion(sSearch);
            //fetch and sort results
            List<FileConversion> conversions = new List<FileConversion>();
            if (asc)
            {
                var pages2skip = (iDisplayStart);
                var sqlRequest = new System.Data.SqlClient.SqlCommand();
                conversions = (from fc in _dataContext.FileConversions
                               join cs in _dataContext.ConversionStatuses on fc.Id equals cs.FileConversionId
                               join rts in _dataContext.ReturnSettings on fc.ReturnSettingId equals rts.Id
                               join r in _dataContext.Returns on rts.ReturnId equals r.Id
                               join e in _dataContext.Entities on r.EntityId equals e.Id
                               join a in _dataContext.Accounts on e.AccountId equals a.Id
                               where ((fc.CurrentStatusCode == ConversionStatusCode.Processing) || (fc.CurrentStatusCode == ConversionStatusCode.Ready) || (fc.CurrentStatusCode == ConversionStatusCode.Error) ||
                                (fc.CurrentStatusCode == ConversionStatusCode.ValidationErrors) || (fc.CurrentStatusCode == ConversionStatusCode.Pending))
                               select fc).ToList().Where(p => GetDataByCondition(p, sSearch)).OrderBy(sort).Distinct().Skip(pages2skip).Take(iDisplayLength).ToList();
            }
            else
            {
                conversions = (from fc in _dataContext.FileConversions
                               join cs in _dataContext.ConversionStatuses on fc.Id equals cs.FileConversionId
                               join rts in _dataContext.ReturnSettings on fc.ReturnSettingId equals rts.Id
                               join r in _dataContext.Returns on rts.ReturnId equals r.Id
                               join e in _dataContext.Entities on r.EntityId equals e.Id
                               join a in _dataContext.Accounts on e.AccountId equals a.Id
                               where ((fc.CurrentStatusCode == ConversionStatusCode.Processing) || (fc.CurrentStatusCode == ConversionStatusCode.Ready) || (fc.CurrentStatusCode == ConversionStatusCode.Error) ||
                                (fc.CurrentStatusCode == ConversionStatusCode.ValidationErrors) || (fc.CurrentStatusCode == ConversionStatusCode.Pending))
                               select fc).ToList().Where(p => GetDataByCondition(p, sSearch)).OrderByDescending(sort).Distinct().Skip(iDisplayStart).Take(iDisplayLength).ToList();
            }
            return conversions;
        }
        private bool GetDataByCondition(FileConversion fileConversion, string sSearch)
        {
            if (sSearch == null)
            {
                sSearch = String.Empty;
            }
            if (fileConversion.FileName.Contains(sSearch)
                || fileConversion.ReturnSetting.Return.Entity.Account.Name.Contains(sSearch)
                || fileConversion.ConversionStatuses.Any(s => s.UserName.Contains(sSearch) || s.Date.ToShortDateString().Contains(sSearch))
                || fileConversion.CurrentStatusCode.ToString().Contains(sSearch))
            {
                return true;
            }
            return false;
        }
