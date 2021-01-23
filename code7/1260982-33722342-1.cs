    List<string>ls=System.IO.Directory.GetFiles("C:\\sampleDir\\").ToList();
    foreach( string  c in ls)
    { 
        using (var fu=new Bitmap(Image.FromFile( c), new Size(200, 200)))
        {
            fu.Save("\\thumbs\\"+c);
        }
    }
