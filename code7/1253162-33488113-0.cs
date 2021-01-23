    using( Image image = Image.FromFile( Server.MapPath( path ) ) ) {
        float aspectRatio = (float)image.Size.Width / (float)image.Size.Height;
        int newHeight = 200;
        int newWidth = (ToInt32)( aspectRatio * newHeight );
           
        using( Bitmap thumbBitmap = new System.Drawing.Bitmap( newWidth, newHeight ) )
        using( Graphics thumbGraph = Graphics.FromImage( thumbBitmap ) ) {
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage( image, imageRectangle );
            String outputFileName = this.Server.MapPath( "~/images/galeria/thumb" );
            outputFileName = Path.Combine( outputFileName, Path.GetFileNameWithoutExtension( path ) ) + ".jpg";
            // Use code from here to save as a JPEG: https://msdn.microsoft.com/en-us/library/bb882583(v=vs.110).aspx
            thumbBitmap.Save( outputFileName, jpegEncoder, jpegEncoderParameters );
        }
    }
