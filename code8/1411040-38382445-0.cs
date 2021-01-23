             Image<Gray, Byte> coloredMotion2 = new Image<Gray, Byte>(frame1.Size);
              for (int i = 0; i < coloredMotion2.Width; i+=2)
              {
                  for (int j = 0; j < coloredMotion2.Height; j+=2)
                  {
                      dx = (int)CvInvoke.cvGetReal2D(velx, j, i);
                      dy = (int)CvInvoke.cvGetReal2D(vely, j, i);
                      int pomi = i + dx;
                      int pomj = j + dy;
                      if (i != pomi && j != pomj)
        // uncoment line below if you want lines but it needs rgb image not gray                            {
       //CvInvoke.cvLine(coloredMotion, new Point(i,j),new Point(i+dx,j+dy), new   MCvScalar(255,0,0), 1, Emgu.CV.CvEnum.LINE_TYPE.CV_AA, 0);                          
      CvInvoke.cvCircle(coloredMotion2, new Point(pomi, pomj), 1, new MCvScalar(255,255,255), 1, Emgu.CV.CvEnum.LINE_TYPE.CV_AA, 0); 
                      }
       motionImageBox.Image = coloredMotion2;
