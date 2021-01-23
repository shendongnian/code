    // same code to get input and output data
    string nurseryData = Properties.Resources.nursery;
    
    string[] inputColumns =
    {
        "parents", "has_nurs", "form", "children",
        "housing", "finance", "social", "health"
    };
    
    string outputColumn = "output";
    
    DataTable table = new DataTable("Nursery");
    table.Columns.Add(inputColumns);
    table.Columns.Add(outputColumn);
    
    string[] lines = nurseryData.Split(
        new[] { Environment.NewLine }, StringSplitOptions.None);
    
    foreach (var line in lines)
        table.Rows.Add(line.Split(','));
    
    
    Codification codebook = new Codification(table);
    
    DataTable symbols = codebook.Apply(table);
    
    double[][] inputs = symbols.ToArray(inputColumns);
    int[] outputs = Matrix.ToArray<int>(symbols, outputColumn);
    
    //SVM
    IKernel kernel = new Linear();
    
    // Create the Multi-class Support Vector Machine using the selected Kernel
    int inputDimension = inputs[0].Length;
    int outputClasses = codebook[outputColumn].Symbols;
    var ksvm = new MulticlassSupportVectorMachine(inputDimension, kernel, outputClasses);
    
    // Create the learning algorithm using the machine and the training data
    var ml = new MulticlassSupportVectorLearning(ksvm, inputs, outputs)
    {
        Algorithm = (svm, classInputs, classOutputs, i, j) =>
        {
            return new SequentialMinimalOptimization(svm, classInputs, classOutputs)
            {
                CacheSize = 0
            };
        }
    };
    
    double SVMerror = ml.Run(); // should be around 0.09
