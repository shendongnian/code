    public ActionResult Action(int id)
            {
              if(id == 10)
                {
                   Model.Message = "Success";
                }
                return View(Model);
            }
