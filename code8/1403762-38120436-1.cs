    class Telephone 
    {
      public string id;
      public string contactN;
    }
    [HttpPost] //it means this method will only be activated in the post event
    public JsonResult UpdateUserContacts(Telephone[] contactsData)
     {
            //Do something...
     }
