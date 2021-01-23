                Mat i1 = new Mat("D:/New folder/images/Fit01.jpg", LoadImageType.Color);
                Mat i2 = new Mat("D:/New folder/images/Fit02.jpg", LoadImageType.Color);
                Mat i3 = new Mat("D:/New folder/images/Fit02.jpg", LoadImageType.Color);
                using (VectorOfMat vmsrc = new VectorOfMat(i1, i2, i3))
                {
                    Image<Bgr, byte> res = new Image<Bgr, byte>(1000, 750);
                    Mat result = new Mat();
                    Stitcher stitcher = new Stitcher(false);
                    stitcher.Stitch(vmsrc, result);
                    ImageViewer.Show(result);
                } 
