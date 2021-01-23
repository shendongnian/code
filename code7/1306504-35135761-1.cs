    /// <summary>
    /// Find contours using the specific memory storage
    /// </summary>
    /// <param name="method">The type of approximation method</param>
    /// <param name="type">The retrieval type</param>
    /// <param name="stor">The storage used by the sequences</param>
    /// <returns>
    /// Contour if there is any;
    /// null if no contour is found
    /// </returns>
    public static VectorOfVectorOfPoint FindContours(this Image<Gray, byte> image, ChainApproxMethod method = ChainApproxMethod.ChainApproxSimple,
        Emgu.CV.CvEnum.RetrType type = RetrType.List) {
        // Check that all parameters are valid.
        VectorOfVectorOfPoint result = new VectorOfVectorOfPoint();
        if (method == Emgu.CV.CvEnum.ChainApproxMethod.ChainCode) {
            throw new ColsaNotImplementedException("Chain Code not implemented, sorry try again later");
        }
        CvInvoke.FindContours(image, result, null, type, method);
        return result;
    }
