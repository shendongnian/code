    public class CreatePersonData
    {
         public string Id{get; set;}
         public string name {get; set;}
         public string address {get; set;}
    }
    public ActionResult CreatePerson(int ID)
    {
        CreatePersonData person=new CreatePersonData();
        var loadPerson=(CreatePersonData)TempData.Peek("person"); //cast the object from TempData
        if(loadPerson!=null && loadPerson.Id==ID)
        { 
            person=loadPerson;
        }
        else
        {
             var user=(from u in tbl_user select u where u.ID=ID);
             person.name=user.name;
             person.address=user.address;
        }
        return View(person);
    }
