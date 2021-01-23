     public string ClassImage
            {
                get { return _classImage; }
                set
                {
                    _classImage = value;
                    OnPropertyChanged(nameof(ClassImage));
    
                }
            }
     foreach (var PlayerClass in ListOfPlayerClasses)
                {
                   
                    ClassImage = @"/path/folders/" + PlayerClass.Name + ".png";
                    PlayerClass.ClassImage = ClassImage;
                }
