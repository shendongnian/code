     object saveAction= new 
                {
                    c = (int)Enums.Controls.Save,
                    t = Enums.Controls.Save.ToString()
                };
    object submitAction = new
            {
                 c = (int)Enums.Controls.Submit,
                 t = Enums.Controls.Submit.ToString()
            };
    
    if (actions.Exists(a => a.Equals(saveAction)))
                  {
                      actions.Remove(submitAction);
                  }
