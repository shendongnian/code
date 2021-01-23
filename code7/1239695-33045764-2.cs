    public IQueryable<GroupMember> GetGroupMember(int SelectedRiskTypeID)
    {
      return _DBContext.GroupMembers
        .Where(gm=>gm.RiskGroupHasGroupTypes
          .Any(rghgt=>rghg‌​t.RiskGroup.ID==SelectedRiskGroupTypeID))
    }
