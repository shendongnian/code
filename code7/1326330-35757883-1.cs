        [CustomAction]
        public static ActionResult UpdateComboBoxes(Session session)
        {
            session.Log("Begin Custom Action UpdateComboBoxes");
            try
            {
                var database = session.Database;
                    using (var view = database.OpenView("SELECT * FROM ComboBox WHERE Property = 'IIS_SITE'"))
                    {
                        view.Execute();
                        session.Log("Executed view");
                        var index = view.Database.CountRows("ComboBox", "Property = 'IIS_SITE'");
                        using (var serverManager = new ServerManager())
                        {
                            foreach (var site in serverManager.Sites)
                            {
                                if (!string.IsNullOrEmpty(site.Name))
                                {
                                    var record = session.Database.CreateRecord(4);
                                    //Property
                                    record.SetString(1, "IIS_SITE");
                                    //Order
                                    record.SetString(2, (++index).ToString());
                                    //Value
                                    record.SetString(3, site.Name);
                                    //Text
                                    record.SetString(4, site.Name);
                                    view.InsertTemporary(record);
                                    session.Log("Inserted new record");
                                }
                            }
                        }
                        session.Log("Closing the view");
                    }
            }
            catch (Exception e)
            {
                session.Log(string.Format("ERROR in UpdateComboBoxes: {0}", e.Message));
                session.Log(e.StackTrace);
                var inner = e.InnerException;
                if(inner != null)
                {
                    session.Log(string.Format("{0}{1}", "\t", inner.Message));
                    session.Log(string.Format("{0}{1}", "\t", inner.StackTrace));
                }
                while (inner != null && (inner = inner.InnerException) != null)
                {
                    session.Log(string.Format("{0}{1}", "\t", inner.Message));
                    session.Log(string.Format("{0}{1}", "\t", inner.StackTrace));
                }
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }
