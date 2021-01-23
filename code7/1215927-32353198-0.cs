                            if (string.IsNullOrEmpty(hourString))
                        {
                            emptyHours++;
                            int count = project.Count();
                            if (count > 1)
                            {
                                ModelState.AddModelError("hours_" + projectNumber, "Du måste skriva in tid på alla project.");
                            }
                            projectData.Projects[projectData.Projects.Count - 1].Hours = projectData.Times.WorkedHours;
                        }
