     public IList<ShiftDate> GetDuplicateShiftsByOrg(int orgID)
        {
            IList<ShiftDate> AllDates = _UoW.ShiftDates
                .Get(s => s.Shift.organisationID == orgID)
                .Where(s=>s.assignedUserID != null)
                .ToList();
            var DuplicateDates = new List<ShiftDate> { };
            /// 1. Group all shifts assigned to user
            var groupUserShifts = AllDates.GroupBy(s=>s.assignedLocumID.Value).Where(g => g.Skip(1).Any());
            foreach (var group in groupUserShifts)
            {
                /// 2. Group all shifts assigned to user on the same date
                var groupUserSameDates = group.GroupBy(sd => sd.shiftStartDate.Date).Where(a => a.Count() > 1).ToList();
                
                if (groupUserSameDates.Count() > 1)
                {
                    foreach (var dategroup in groupUserSameDates)
                    {
                        /// 3. Return all shifts where user hass been assigned on the same date
                        foreach (ShiftDate shiftDate in dategroup)
                        {
                            DuplicateDates.Add(shiftDate);
                        }
                    }
                }
            }
            return DuplicateDates.ToList();
        }
