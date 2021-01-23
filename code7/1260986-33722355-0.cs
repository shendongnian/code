    List<string>ls=System.IO.Directory.GetFiles("C:\\sampleDir\\").ToList();
    foreach( string  c in ls)
    {  
        using(var image = Image.FromFile(c))
        using(var fu=new Bitmap(image, new Size(200, 200)))
        {
            fu.Save("\\thumbs\\"+c);
        }
    }
