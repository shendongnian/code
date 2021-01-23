            Android.Graphics.BitmapFactory.Options options = new Android.Graphics.BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };
            Android.Graphics.Bitmap result = Android.Graphics.BitmapFactory.DecodeByteArray(bitmapArray, 0, byteArrayLength, options);
            //int imageHeight = options.OutHeight;
            //int imageWidth = options.OutWidth;
