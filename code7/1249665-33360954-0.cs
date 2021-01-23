    var data = from EP in DbContext.EmployeeProfesionalDtls
                       join DM in DbContext.DesignationMasters on EP.DesigId equals DM.DesigId
                       join DP in DbContext.DepartmentMasters on new { DepId = EP.DepId } equals new { DepId = DP.DeptId }
                       select new Test()
                       {
                           ProfId = EP.ProfId,
                           EmpId = EP.EmpId,
                           EntryDate = DM.EntryDate,
                           DeptName = DP.DeptName,
                           DepartmentUnitID = DP.UnitId,
                           DepartmentEntryDate = DP.EntryDate
                       }
