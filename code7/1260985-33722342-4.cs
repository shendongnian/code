    List<string>ls=System.IO.Directory.GetFiles("C:\\sampleDir\\").ToList();
    foreach( string  c in ls)
    { 
        using (var img = Image.FromFile(c))
        using (var fu=new Bitmap(img, new Size(200, 200)))
        {
            fu.Save("\\thumbs\\"+c);
        }
    }
