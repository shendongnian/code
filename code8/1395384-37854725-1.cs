    <script type="text/javascript">
    $.ajax({
        cache: false,
        url: "@Url.Action("Download", "Controller")",
        data: { imageUrl: [your image link here], fileName: [image filename] },
        dataType: 'json',
        success: function (data) {
           // download image to client's browser
        },
        error: function (err) {
           alert(err);
        }
    });
    </script>
    
    // note that input variable should match with AJAX call data parameter
    public ActionResult Download(String imageUrl, String fileName) 
    {
        // check if image URL exists by reading response header
        boolean fileExist;
        HttpWebResponse response = null;
        var request = (HttpWebRequest)WebRequest.Create(imageUrl);
        request.Timeout = 10000; // in milliseconds, e.g. 10 sec
        request.Method = "HEAD";
        
        try
        {
            response = (HttpWebResponse)request.GetResponse(); // get validity response
            fileExist = response.StatusCode == HttpStatusCode.OK;
            if (fileExist)
            {
                HttpClient client = new HttpClient();
                byte[] data = client.GetByteArrayAsync(imageUrl);
                return File(data, "application/jpg", fileName);
            }
            else
            {
                return new HttpStatusCodeResult(404, "Image not found");
            }
        }
        catch (Exception err)
        {
             return new HttpStatusCodeResult(400, "Bad request" + err.Message); // 404 also eligible here, assume it is bad request
        }
        finally
        {
            if (response != null) 
            {
                response.Close();
            }
        }
    }
