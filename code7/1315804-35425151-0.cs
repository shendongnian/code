    public ActionResult MachineInfo(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                FarmDetail farmdetail = db.FarmDetails.Where(x => x.FarmId == id).FirstOrDefault();
                if (farmdetail == null)
                {
                    return HttpNotFound();
                }
                return View(farmdetail);
            }
