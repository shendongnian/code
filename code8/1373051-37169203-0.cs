     public Task<ActionResult> DoFileStuff() 
     {
        MemoryStream m = new MemoryStream();
        await Request.Files[0].InputStream.CopyToAsync(m);
        new Thread(DoMoreWork).Start();
     }
