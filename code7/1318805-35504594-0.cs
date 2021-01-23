    get 
    {
        int count = 0;
        foreach(Skill skill in ((EmployeeViewModel)SelectedRow).Skills)
        {
            if(skill.IsChecked)
            {
                count++;
            }
        }
        return count;
    }
