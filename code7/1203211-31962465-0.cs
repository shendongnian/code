        public List<int> GetFilteredEmployeeIds(int? brandId)
        {
            List<int> employeeIds = GetFilteredEmployeeIdsBySearchTerm();
            return employeeIds.Where(e => MemberIsEmployeeWithBrand(e, brandId)).ToList();
        }
        private bool MemberIsEmployeeWithBrand(int employeeId, int? brandId)
        {
            Member m = new Member(employeeId);
            if (!m.IsInGroup("Employees"))
            {
                return false;
            }
            int memberBrandId = Convert.ToInt32(m.getProperty("brandID").Value);
            return brandId == memberBrandId;
        }
