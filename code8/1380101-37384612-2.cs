    public ActionResult CheckBoxGet()
    {
        var list = new List<FormInputs>
        {
             new FormInputs { Id = 1, Name = "Aquafina", Checked = false },
        new FormInputs { Id = 2, Name = "Mulshi Springs", Checked = false },
         new FormInputs { Id = 3, Name = "Alfa Blue", Checked = false },
         new FormInputs { Id = 4, Name = "Atlas Premium", Checked = false },
         new FormInputs { Id = 5, Name = "Bailley", Checked = false },
         new FormInputs { Id = 6, Name = "Bisleri", Checked = false },
         new FormInputs { Id = 7, Name = "Himalayan", Checked = false },
         new FormInputs { Id = 8, Name = "Cool Valley", Checked = false },
         new FormInputs { Id = 9, Name = "Dew Drops", Checked = false },
         new FormInputs { Id = 10, Name = "Dislaren", Checked = false },
        };
        MyViewModel mvm = new MyViewModel(){inputCollection = list , isList = true}
        return this.View("Index", mvm); 
    }
