    private void DeleteSelectedSkillFromSelectedEmployee()
    {
      if(Company != null &&
         Company.SelectedEmployee != null && 
         Company.SelectedEmployee.Skills != null)
      {           
        Company.SelectedEmployee.Skills.Remove(Company.SelectedEmployee.SelectedSkill);
        EmployeeSkillsListView.ScrollIntoView(Company.SelectedEmployee.Skills.Last());
      }
    }
