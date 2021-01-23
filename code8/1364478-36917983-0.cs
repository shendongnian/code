    [HttpPost]
        public ActionResult About(List<Requirements> requirements)
        {
         foreach (var item in requirements)
            {
             
              if (item.IsSelected == true)
              {
                //perform some operation
              }
            }
