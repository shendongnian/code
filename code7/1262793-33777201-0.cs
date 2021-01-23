        public ActionResult Edit(EditGameVM model, int id = 0) 
        {
            if (id == 0)
            {
                id = 1;
            }
            var gameList = objBs.gameBs.GetByID(id);
            model = new EditGameVM
            {
                gameID = id,
                gameName = gameList.gameName,
                gamePicture = gameList.gamePicture,
                gameRule = gameList.gameRule,
                description = gameList.description
            };
            return View(model);
        }
