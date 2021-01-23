     PrintDocument pd = new PrintDocument();
     pd.PrintPage += (sender, args) =>
     {
           Image i = Image.FromFile("C://tesimage.PNG");
           args.Graphics.DrawImage(i, args.PageBounds);
     };
     pd.Print();
