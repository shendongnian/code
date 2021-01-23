     /// <summary>
     /// The download action returns the file as a File download.
     /// </summary>
     /// <param name="filename"></param>
     /// <returns></returns>
     [AllowAnonymous]
     public FilePathResult Download(String filename)
     {
        String myfile = Path.Combine(HttpContext.Server.MapPath("~/Content/audiofiles/"), filename);
        return File(myfile, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
     }
