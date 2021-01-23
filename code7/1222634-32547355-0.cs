                    /*var ILU = db.itemlookuptypes.Find(u.ItemLookUpID);
                    if (ILU != null)
                    {
                        IMV.Name = ILU.Name;
                    }
                    IMV.Name = "JM";*/
                    using(packinglistEntities db2 = new packinglistEntities())
                    {
                        var ILU = db2.itemlookuptypes.Find(u.ItemLookUpID);
                        if (ILU != null)
                        {
                            IMV.Name = ILU.Name;
                        }
                    }
