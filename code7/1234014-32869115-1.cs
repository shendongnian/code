    private void UpdateSkills(Employee employee, IEnumerable<int> updatedSkills)
    {
        if (employee.Skills != null)
        {
            var updatedSkillsList = updatedSkills as IList<int> ?? updatedSkills.ToList();
            var addedSkills = updatedSkillsList.Except(employee.Skills.Select(x => x.Id));
            var removedSkills = employee.Skills.Select(x => x.Id).Except(updatedSkillsList);
            addedSkills.ForEach(x => employee.Skills.Add(_skillService.GetById(x)));
            removedSkills.ForEach(x => employee.Skills.Remove(_skillService.GetById(x)));
             // here 
             _employeeService.Update(employee);
        }
        else
        {
            employee.Skills = new List<Skill>();
            newSkills.ForEach(x => employee.Skills.Add(_skillService.GetById(x)));
        }
    }
