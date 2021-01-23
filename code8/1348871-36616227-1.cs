    Mat matToCompare;
    using (var memStream = new MemoryStream())
    {
    	byte[] bytes = face.Histogram;
    	BinaryFormatter bformatter = new BinaryFormatter();
    	memStream.Write(bytes, 0, bytes.Length);
    	memStream.Seek(0, SeekOrigin.Begin);
    	matToCompare = bformatter.Deserialize(memStream) as Mat;                                    
    }
    
    distance = CvInvoke.CompareHist(histSource, matToCompare, HistogramCompMethod.Bhattacharyya);
