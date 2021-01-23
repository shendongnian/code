    public bool UpdateEmployee(Employee employee)
        {
            var entity = _dbContext.Employees.Where(c => c.Id == employee.Id).AsQueryable().FirstOrDefault();
            if (entity == null)
            {
                _dbContext.Employees.Add(employee);
            }
            else
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(employee);              
            }
            return _dbContext.SaveChanges() > 0;
        }
