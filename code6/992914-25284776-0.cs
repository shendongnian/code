    [HttpPost]
    public ActionResult FileUpload(IEnumerable<HttpPostedFileBase> file_Uploader, ClassName Model)
    {
         if (file_Uploader != null && file_Uploader.ContentLength > 0)
                    {
                         foreach(var item in file_Uploader)
                          {
                              var content = new byte[item .ContentLength];
                              item .InputStream.Read(content, 0, file_Uploader.ContentLength);
                              var document= reslandEntities.ARTIFACT.Where(m => m.ID == 1).SingleOrDefault();
                              document.CONTENT = item.ToArray();
                              document.filetype=Model.dropdownlistID;
                            }
                          reslandEntities.SaveChanges();
                      }
                }
    }
