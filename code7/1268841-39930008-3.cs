    [route.System.Web.Http.HttpPost]
            [HttpRoute("api/Home/Update_Profile")]
            public JsonResult Update_Profile([FromBody]UpdateProfileViewModel updateprofileviewmodel)
            {
                UserModel usermodelforemail = Helper.FindUserByEmail(updateprofileviewmodel.email);
                System.Web.Mvc.JsonResult usertoreturn = new System.Web.Mvc.JsonResult();
                UserModel usermodel = new UserModel();
                usermodel = FridgeHelper.FindUserByObjectId(updateprofileviewmodel.userid);
                usermodel.FirstName = updateprofileviewmodel.firstname;
                usermodel.MiddleName = updateprofileviewmodel.middlename;
                usermodel.LastName = updateprofileviewmodel.lastname;
                usermodel.Email = updateprofileviewmodel.email;
                
                 //save photo
                if (updateprofileviewmodel.base64String != null)
                {
                    byte[] imageBytes = Convert.FromBase64String(updateprofileviewmodel.base64String);
                    MemoryStream ms = new MemoryStream(imageBytes, 0,
                      imageBytes.Length);
                    // Convert byte[] to Image
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    Image image = Image.FromStream(ms, true);
                    string filenametosave = usermodel._id + "." + System.Drawing.Imaging.ImageFormat.Jpeg;
                    var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/UserProfilePictures/" + filenametosave);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    image.Save(path);
                    usermodel.Photo = filenametosave;
                }
           
                bool resultvalue = false;
                resultvalue = Helper.UpdateUser(usermodel);
               
                if (resultvalue)
                {
                    usertoreturn.Data = "true";
                }
                else
                {
                    usertoreturn.Data = "false";
                }
                return usertoreturn;
                   
            }
