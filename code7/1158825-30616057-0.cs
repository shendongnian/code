     public FileResult Download()
     {
        byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\folder\myfile.ext");
        string fileName = "myfile.ext";
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
     }
