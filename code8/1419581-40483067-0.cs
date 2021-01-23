     public static class Extension
    {
        public static VectorOfVectorOfPointF FindContour(this UMat img,Mat hierarchy = null, Emgu.CV.CvEnum.RetrType type = Emgu.CV.CvEnum.RetrType.List,Emgu.CV.CvEnum.ChainApproxMethod method = Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple  )
        {
            VectorOfVectorOfPointF contours = new VectorOfVectorOfPointF();
            CvInvoke.FindContours(img, contours, hierarchy, type, method);
            return contours;
        }
    
    }
