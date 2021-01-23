                var Valid = False;
                using (UserContext db = new UserContext())
                {
                    Valid = db.Users.Any(u => u.Name == model.Name && u.Password== model.Password);
                }
                if (Valid)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Users");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
