    private async void SaveSoftwareBitmapToFile(SoftwareBitmap softwareBitmap, StorageFile outputFile)
    {
        using (IRandomAccessStream stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            // Create an encoder with the desired format
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
    
            // Set the software bitmap
            encoder.SetSoftwareBitmap(softwareBitmap);
    
            // Set additional encoding parameters, if needed
            encoder.BitmapTransform.ScaledWidth = 320;
            encoder.BitmapTransform.ScaledHeight = 240;
            encoder.BitmapTransform.Rotation = Windows.Graphics.Imaging.BitmapRotation.Clockwise90Degrees;
            encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
            encoder.IsThumbnailGenerated = true;
    
            try
            {
                await encoder.FlushAsync();
            }
            catch (Exception err)
            {
                switch (err.HResult)
                {
                    case unchecked((int)0x88982F81): //WINCODEC_ERR_UNSUPPORTEDOPERATION
                                                     // If the encoder does not support writing a thumbnail, then try again
                                                     // but disable thumbnail generation.
                        encoder.IsThumbnailGenerated = false;
                        break;
                    default:
                        throw err;
                }
            }
    
            if (encoder.IsThumbnailGenerated == false)
            {
                await encoder.FlushAsync();
            }
    
    
        }
    }
