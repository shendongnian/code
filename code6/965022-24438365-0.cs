    var filelist = Search();
    foreach (var s in filelist) {
         string fn = System.IO.Path.GetFileName(s);
         string dest = System.IO.Path.Combine("c:\\tmp", fn);
         System.IO.File.Copy(s, dest, true);
    }
