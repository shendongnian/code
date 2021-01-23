    [Route("detailedvarinfo/{VarGUID}")]
    public async Task<IHttpActionResult> GetDetailedVarInfo(string VarGUID)
    {
        if (!User.IsInRole("Admin"))
        {
            var DashboardAccess = (from DR in AuthDb.DashboardAccessVars
                                   where DR.ApplicationUser.Id == userInfo.Id
                                   select DR).
                                   AsEnumerable()
                                   .Select(x => new
                                   {
                                       VarGUID = x.VarGUID
                                   }).ToList();
            var FilteredVarInfo = VarInfo.Join(DashboardAccess, x => x.VarGUID, y => y.VarGUID, (x, y) => x);
            if (FilteredVarInfo.Any())
            {
                return Ok(FilteredVarInfo.FirstOrDefault());
            }
            else
            {
                return NotAllowedOk(FilteredVarInfo, StatusReason.StatusFiltered);
            }
        }
    }
