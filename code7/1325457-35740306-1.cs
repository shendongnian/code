    public ActionResult Create( ExampleViewModel ivm ){
              if(ivm.Foto ==null){
                   WebImage imagenW = WebImage.GetImageFromRequest();
                   if (imagenW != null)
                   {
                       ivm.Foto = "data:image/png;base64," + Convert.ToBase64String(imagenW.GetBytes());
                   }
               }
               if (Model.IsValid){
                 //do something...
               }
               return (View(ivm))
            }
