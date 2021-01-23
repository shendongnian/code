    var httpContent = NewResponse.Content; 
    using(var newFile = System.IO.File.Create(@"C:\MyNewFile.pdf"))
    { 
        var stream = await httpContent.ReadAsStreamAsync();
        await stream.CopyToAsync(newFile);
    }
