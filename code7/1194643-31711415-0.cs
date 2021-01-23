    [HttpPost]
        public ActionResult FormSubmit(FormCollection form)
        {
            string id= form["id"].ToString();
      return RedirectToAction("Index");
            }
        }
