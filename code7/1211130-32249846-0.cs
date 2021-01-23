                            if (ModelState.IsValid)
                        {
                            projectData.SaveToDatabase(Constants.CurrentUser(User.Identity.Name));
                            ViewData["posted"] = true;
                            //Loads default settings and projects.
                            projectData = new NewTimeReportModel();
                            LoadDefaultSettings(projectData);
                        }
