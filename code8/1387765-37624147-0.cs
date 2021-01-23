      [HttpPost]
        public ActionResult Articles(bool UnavailableProducts = false)
        {
            if (Session["employee"] != null)
            {
                Session["UnavailableProducts"] = UnavailableProducts;
                List<Article> articles;
                try
                {
                    articles = system.OverviewArticles();
                }
                catch
                {
                    articles = null;
                    ModelState.AddModelError("DatabaseError", "Database error de data kon niet geladen worden!");
                }
                return View(articles);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
