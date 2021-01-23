     public void savePicture(List<DBPicture> pics)
            {
                //Getting a list of pics of type DBPicture as you mentioned in class
                try
                {
                    foreach(DBPicture pic in pics)
                    //Using the model created from database 
                    using (DataModel.PicEntities picContext = new PicEntities())
                    {
    
                        DataModel.DBPicture dbPic = new DBPicture();
                        dbPic.idPic = pic.idPicture;
                        dbPic.idLoc = pic.idLocation;
                        picContext.Meetings.Add(dbPic);
                        picContext.SaveChanges();
                    }
                }
                catch
                {
    
                }
    
            }
