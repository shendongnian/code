        #region Transformation Services
  
        /// <summary>
        ///  Transforms the given Point3D by this matrix, projecting the 
        ///  result back into the W=1 plane. 
        /// </summary>
        /// <param name="point">Point to transform. 
        /// <returns>Transformed point.</returns>
        public Point3D Transform(Point3D point)
        {
            MultiplyPoint(ref point); 
            return point;
        } 
