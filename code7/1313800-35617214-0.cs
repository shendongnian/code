    HoughLineTransformation lineTransform = new HoughLineTransformation( );
    // apply Hough line transofrm
    lineTransform.ProcessImage( sourceImage );
    Bitmap houghLineImage = lineTransform.ToBitmap( );
    // get lines using relative intensity
    HoughLine[] lines = lineTransform.GetLinesByRelativeIntensity( 0.5 );
    
    foreach ( HoughLine line in lines )
    {
        // ...
    }
