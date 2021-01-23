    [Test]
      public void TestMorphEx()
      {
         Mat kernel1 = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(3, 3), new Point(1, 1));
         Matrix<byte> kernel2 = new Matrix<byte>(new Byte[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } });
         //StructuringElementEx element2 = new StructuringElementEx(new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } }, 1, 1);
         Image<Bgr, Byte> tmp = new Image<Bgr, byte>(100, 100);
         Image<Bgr, Byte> tmp2 = tmp.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Gradient, kernel1, new Point(-1, -1), 1, CvEnum.BorderType.Default, new MCvScalar());
         Image<Bgr, Byte> tmp3 = tmp.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Gradient, kernel2, new Point(-1, -1), 1, CvEnum.BorderType.Default, new MCvScalar());
         //Image<Bgr, Byte> tmp2 = tmp.MorphologyEx(element1, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_GRADIENT, 1);
         //Image<Bgr, Byte> tmp3 = tmp.MorphologyEx(element2, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_BLACKHAT, 1);
      }
