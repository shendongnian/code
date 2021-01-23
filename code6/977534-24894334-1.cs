    public ActionResult Create([Bind(Include="Window_ID,Rentalman_ID,BranchAreaNum,FirstName,LastName")] tblUserAdded tbluseradded)
        {
            if (ModelState.IsValid)
            {
                if (tbluseradded.Window_ID == tbluseradded.Rentalman_ID)
                {
                    System.Diagnostics.Debug.WriteLine("The user should already have access since the user's Windows ID and RentalMan ID are the same. Contact IAUnit for help on the issue");
                }
                else
                {
                    // Rewrite stored procedure in form of raw SQL
                    string returnVal = "0";
                    // This will check to see if a user has already been added to tblUser and tblUserAdded
                    string checkTblUserAdded = db.Database.SqlQuery<string>("SELECT [Window ID] FROM dbo.tblUserAdded WHERE " + 
                        "[Window ID] = '" + tbluseradded.Window_ID + "' AND " +
                        "[Rentalman ID] = '" + tbluseradded.Rentalman_ID + "' AND " +
                        "[BranchAreaNum] = '" + tbluseradded.BranchAreaNum + "' AND " +
                        "[FirstName] = '" + tbluseradded.FirstName + "' AND " +
                        "[LastName] = '" + tbluseradded.LastName + "'").FirstOrDefault<string>();
                    string checkTblUser = db.Database.SqlQuery<string>("SELECT [UserID] FROM dbo.tblUser WHERE " +
                        "[UserID] = '" + tbluseradded.Window_ID + "' AND " +
                        "[RentalManID] = '" + tbluseradded.Rentalman_ID + "'").FirstOrDefault<string>();
                    // Add new user if not found in either tblUserAdded or tblUser
                    if (checkTblUser == null && checkTblUserAdded == null)
                    {
                        System.Diagnostics.Debug.WriteLine("We can add the user now! We did it!");
                        returnVal = "1";
                        // Do something here
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("This user already has access");
                        returnVal = "2";
                        // Do something here
                    }
                    System.Diagnostics.Debug.WriteLine("The return value is: " + returnVal);
                    System.Diagnostics.Debug.WriteLine("Please break here!");
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(tbluseradded);
        }
