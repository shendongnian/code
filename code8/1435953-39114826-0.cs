    foreach (var ob in all_request_list.Where(x => x.StartDate != x.EndDate))
            {
                int consq_dates = ob.EndDate.DateDiff(ob.StartDate);                
                for (int i = 0; i <= consq_dates; i++)
                {
                    var newDate = ob.StartDate.AddDays(i);
                    combined_list.Add(new { ShiftID = ob.ShiftID, SkillID = ob.SkillID, EmployeeID = ob.EmployeeID, AssignDate = newDate , ProfileID = ob.ProfileID });
                }
            }
