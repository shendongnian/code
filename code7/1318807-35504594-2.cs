    skill.PropertyChanged += SkillsPropertyChanged
    
    SkillsPropertyChanged(Object sender, PropertyChangedEventArgs e)
    {
      if(e.PropertyName ="IsChecked")
      { 
        //Logic to update the NumberOfSkills
        if(skill.IsChecked)
        {
            NumberOfSkills++;
        }
        else
        {
            NumberOfSkills--;
        }
      }
    }
