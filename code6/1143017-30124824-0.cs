    public static double[][] GetPCAComponents(double[][] sourceMatrix, int dimensions = 20, AnalysisMethod method = AnalysisMethod.Center) 
    {
        // Create Principal Component Analysis of a given source
        PrincipalComponentAnalysis pca = new PrincipalComponentAnalysis(method)
        {
            NumberOfOutputs = dimensions // limit the number of dimensions
        };
    
        // Compute the Principal Component Analysis
        pca.Learn(sourceMatrix);
    
        // Creates a projection of the information
        double[][] pcaComponents = pca.Transform(sourceMatrix);
    
        // Return PCA Components
        return pcaComponents;
    }
