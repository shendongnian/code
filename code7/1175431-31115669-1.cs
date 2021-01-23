    [ValidateInput(false)]
    public void UpdateCar(EntityDto model)
            {
               var html_stuff = model.HTML_Stuff; 
    
                // sanitation and validation
    
                String Select = String.Format("UPDATE Car Set HTML_Stuff = {0} WHERE id = {1}", html_stuff , id);
    
                // Execute DB Command
            }
