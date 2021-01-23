        public static void LoadEmployeeImageToObject(byte[] photo , int employeeId)
        {
            if (HttpContext.Current.Request != null)
            {
                byte[] uploadedImageFromFileControl = GetImageFromUpload();
                bool removeImage = HttpContext.Current.Request["removeImage"] == "on";
                if (HttpContext.Current.Session["AjaxPhoto"] != null)
                {
                    photo = (byte[])HttpContext.Current.Session["AjaxPhoto"];
                }
                else if (uploadedImageFromFileControl != null) photo = uploadedImageFromFileControl;
                else if (employeeId != 0) //load image from db
                {
                    photo = photo;
                }
            }
        }
