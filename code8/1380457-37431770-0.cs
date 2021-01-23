    var projectID = items.FirstOrDefault().projectID;
                        var group=items.FirstOrDefault().sourceGroup;
                     
                        //Loop through changable item
                        foreach(var item in items)
                        {
                        checkPrimeryKey: //return back after changin duplicate item taskID
                            var checkDuplicate = db.ProjectTasks.Where(wh => wh.ProjectID == projectID && wh.TaskID == item.taskID).FirstOrDefault();
                            if (checkDuplicate == null) //If not Duplicate found
                            {
                                string sql = "update ProjectTasks set taskID='" + item.taskID + "' where projectID=" + projectID + " and TaskDesc='" + item.taksName + "'";
                                db.Database.ExecuteSqlCommand(sql);
                            }
                            else //If duplicate found change its task ID and return back to Step:1
                            {
                                string sql = "update ProjectTasks set taskID='" + Guid.NewGuid().ToString().Substring(0, 4) + "' where projectID=" + projectID + " and TaskDesc='" + checkDuplicate.TaskDesc + "'";
                                db.Database.ExecuteSqlCommand(sql);
                                goto checkPrimeryKey;
                            }
                        }
                        db.SaveChanges();
