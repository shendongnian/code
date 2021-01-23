        class PersonDTO {
           public Name {get; set;}
        }
        
        var person = context.People.First();
        var personDTO = new PersonDTO{
          Name = person.Name    
        }
       var json = new JavaScriptSerializer().Serialize(personDTO);
