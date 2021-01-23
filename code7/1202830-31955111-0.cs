		public ActionResult Edit(AccountEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //I was missing these 2 important lines...
                db.Accounts.Attach(vm.Account);
                db.Entry(vm.Account).Collection(a => a.Players).Load();
                if (vm.SelectedPlayers != null)
                {
                    foreach (var player in vm.Account.Players.ToList())
                    {
                        if (vm.SelectedPlayers.Contains(player.Id) == false)
                        {
                            player.Account = null;
                            vm.Account.Players.Remove(player);
                            db.Entry(player).State = EntityState.Modified;
                            vm.SelectedPlayers.Remove(player.Id);
                        }
                    }
                    
                    foreach (var player_id in vm.SelectedPlayers)
                    {
                        var player = db.Players.Where(p => p.Id == player_id).First();
                        player.Account = vm.Account;
                        vm.Account.Players.Add(player);
                        db.Entry(player).State = EntityState.Modified;
                    }
                }else
                {
                    vm.Account.Players.Clear();
                }
                db.Entry(vm.Account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
