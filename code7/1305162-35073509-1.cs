    var query = (from RTHG in _DBContext.RiskTypeHasGroup RTHG
                join RG in _DBContext.RiskGroup on RTHG.RiskGroupID = RG.ID
                join RGHGM in _DBContext.RiskGroupHasGroupMembers on RG.ID = RGHGM.RiskGroupID
                join GM in _DBContext.GroupMember on RGHGM.GroupMemberID = GM.ID
                join GMHSM in _DBContext.GroupMemberHasStaffMember on GM.ID = GMHSM.GroupMemberID
                join SM in _DBContext.StaffMember on GMHSM.StaffMemberID = SM.ID
            where RTHG.RiskTypeID = 1
            select new {RTHG.RiskTypeID,SM.FullName});
