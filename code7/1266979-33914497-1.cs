    void ConvertImageToBW()
        {
            Mat MatToBW = new Mat();
            using (Bitmap SourceImg = Bitmap.CreateBitmap(BitmapFactory.DecodeFile(App._file.Path)))  //App._file.Path  - path of image that we have made by camera 
            {
                if (SourceImg != null)
                {
                    Utils.BitmapToMat(SourceImg,MatToBW);
                    //first we convert to grayscale
                    Imgproc.CvtColor(MatToBW, MatToBW, Imgproc.ColorRgb2gray);
                    //now converting to b/w
                    Imgproc.Threshold(MatToBW, MatToBW, 0.5 * 255, 255, Imgproc.ThreshBinary);
                    using(Bitmap newBitmap = Bitmap.CreateBitmap(MatToBW.Cols(),MatToBW.Rows(),Bitmap.Config.Argb8888))
                    {
                        Utils.MatToBitmap(MatToBW, newBitmap);
                        //put result in your imageView, B/W Image
                        imageView.SetImageBitmap(newBitmap);
                    }
                }
    
            }
        }
