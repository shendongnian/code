     if (ModelState.IsValid)
            {
                WinchesBrand winch = new WinchesBrand
                {
                    WinchBrandId = model.WinchBrandId.Value,
                    WinchBrandName = model.WinchBrandName
                };
                db.Entry(winch).State = EntityState.Modified;
                var ropeToDelete = db.Ropes
                    .Where(r => r.IdWinch == model.WinchBrandId 
                        && !model.RopeList.Contains(r.RopeId))
                        .ToList();
                foreach(var rope in ropeToDelete){
                    rope.IdWinch = null;
                }
                foreach (var ropeId in model.RopeList.Where(w => w > 0))
                {
                    var rope = new Rope { RopeId = ropeId.Value };
                    db.Ropes.Attach(rope);
                    rope.IdWinch = winch.WinchBrandId;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
