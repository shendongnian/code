        public ActionResult GetServer()
        {
            List<server> sList = new Dictionnary<string,object>();
            sList.Add("Totals",new{
                type= "column",
                name= "Totals",
                showInLegend= true,
                dataPoints= new List<dynamic>(){
                  new{ label= "Space", y= 20}/*,
                  new{ label= "label2", y= 30},*/
                 }
                });
            sList.Add("Totals",new{
                type= "column",
                name= "Used",
                showInLegend= true,
                dataPoints= new List<dynamic>(){
                  new{ label= "Space", y= 10}/*,
                  new{ label= "label2", y= 40},*/
                 }
                });
           return Json(sList, "text/json", JsonRequestBehavior.AllowGet);
        }
