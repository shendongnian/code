        [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<ActionResult> Create([Bind(Include = "QuestionText,SelectedItems, SelectedIds")] QuestionModel question)
                {
                    if (ModelState.IsValid)
                    {
    // I need only one Item, but if you want ore more change this line
                        if (question.SelectedIds.Count() == 1)
                        {
    // better use Automapper here, this is unnecessary work
                            var newQuestion = new Question { QuestionText = question.QuestionText};
        
                            var ItemID = question.SelectedIds.First();
        
                            newQuestion.QuestionScale = await this.uoW.ItemRepository.GetRaw().Where(i => i.ItemID == ItemD).FirstAsync();
        
                            this.uoW.QuestionRepository.Insert(newQuestion);
        
                            await this.uoW.Save();
        
                            return this.RedirectToAction("Index");
                        }
                        else
                        {
                            this.logger.Warn("User {0} tried to insert more than one Itemin question {1}", User.Identity.Name, question.QuestionID);
                            ModelState.AddModelError(string.Empty, xyz.Areas.QuestionManagement.Resources.QuestionRes.ErrorTooManyScales);
                        }
                    }
                    else
                    {
    // the SelectedItems are empty in the model - so if you have to redisplay it, repopulate it.
                        await this.GetSelectedItems(question, null);
                    }
        
                    return this.View(question);
                }
