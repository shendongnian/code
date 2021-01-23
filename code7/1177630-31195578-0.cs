        public async Task<ActionResult> ChooseScenario(string charId)
        {
            string currentUser = User.Identity.GetUserId();
            //Convert passed in charId string to related Character object 
            var pFSCharacter = await db.PFSCharacters
                .FirstOrDefaultAsync(c => c.PFSCHARACTERID == charId);
            var pFSScenarios = await db.PFSScenarios
                .Where(
                    i => i.IsActive == true &&
                    i.MinLevel <= pFSCharacter.CharLevel && 
                    i.MaxLevel >= pFSCharacter.CharLevel &&
                    !i.PFSCharacterScenarios
                    .Any(
                        x => x.PFSCharacter.IsCore == pFSCharacter.IsCore &&
                        x.PFSCharacter.PFSUser.PFSUSERID == currentUser))
                    .ToListAsync();
            //pass pFSCharacter to View to pass to next Controller ActionResult
            ViewBag.Character = pFSCharacter;
            //send list of scenarios to the View to be displayed.
            return View(pFSScenarios);
        }
