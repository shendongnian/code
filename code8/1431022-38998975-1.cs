    var mpc = new MultipartContent();
    var sc = new StringContent("value");
    sc.Headers.Add("Content-Disposition", "form-data; name=\"some-label\"");
    mpc.Add(sc);
    var fc = new StreamContent(fs);
    fc.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"my-filename.txt\"");
    mpc.Add(fc);
