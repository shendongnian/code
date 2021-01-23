        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            MaterialDefinition def = repository.GetMaterialDefinition(id);
            UpdateModel(def, "Definition");
            //UpdateModel(def);
            repository.Save();
            return RedirectToAction("Details", new { id = def.mdID });
        }
