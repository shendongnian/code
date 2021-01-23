    public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var appDbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                using( var context = new MyEntities())
                using (var transaction = appDbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var DataModel = new UserMaster();
                            DataModel.Gender = model.Gender.ToString();
                            DataModel.Name = string.Empty;
                            var result = await UserManager.CreateAsync(user, model.Password);//Doing entry in AspnetUser even if transaction fails
                            if (result.Succeeded)
                            {
                                await this.UserManager.AddToRoleAsync(user.Id, model.Role.ToString());
                                this.AddUser(DataModel, context);
                                transaction.Commit();
                                return View("DisplayEmail");
                            }
                            AddErrors(result);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return null;
                        }
                    }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public int AddUser(UserMaster _addUser, MyEntities _context)
        {
            _context.UserMaster.Add(_addUser);
            _context.SaveChanges();
            return 0;
        }
