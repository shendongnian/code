    //Parameter can also be FormCollection
        public ActionResult eventview(string url){ 
               string[] splitURL=url.split('/');  //Considering URL - "calendar/addevent"
               return RedirectToAction(splitURL[1],splitURL[0]);
        }
    
