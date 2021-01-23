	public IQueryable<AccessLevel> TestGetAccessLevelData()
			{
				IQueryable<AccessLevel> AccessLevelGrp = null;
	 
				IQueryable<AccessLevel> AccessLevel = from a in unitOfWork.ACCESS_LEVEL_RXRepository.Get()
															 select new AccessLevel
														{
															AccessLvlId = a.ACCESS_LVL_ID_RX,
															AccessLvlName = a.ACCESS_LVL_NAME,
															GroupCode = "Group A"
														};
	 
				IQueryable<AccessLevel> AccessLevel1 = from a in unitOfWork.ACCESS_LEVEL_RXRepository.Get()
															 select new AccessLevel
															 {
																 AccessLvlId = a.ACCESS_LVL_ID_RX,
																 AccessLvlName = a.ACCESS_LVL_NAME,
																 GroupCode = "Group B"
															 };                      
	 
				var result = AccessLevel.Union(AccessLevel1);          
				return result.OrderBy(c=> c.GroupCode);
			}
	 
