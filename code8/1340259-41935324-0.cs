    var smo = new MulticlassSupportVectorLearning<DynamicTimeWarping, double[][]>()
                {
                    // Set the parameters of the kernel
                    Kernel = new DynamicTimeWarping(alpha: 1, degree: 1)
                };
                // And use it to learn a machine!
                var svm = smo.Learn(words, labels);
                // Create the multi-class learning algorithm for the machine
                var calibration = new MulticlassSupportVectorLearning<DynamicTimeWarping, double[][]>()
                {
                    Model = svm, // We will start with an existing machine
    
                    // Configure the learning algorithm to use SMO to train the
                    //  underlying SVMs in each of the binary class subproblems.
                    Learner = (param) => new ProbabilisticOutputCalibration<DynamicTimeWarping, double[][]>()
                    {
                        Model = param.Model // Start with an existing machine
                    }
                };
                // Configure parallel execution options
                calibration.ParallelOptions.MaxDegreeOfParallelism = 1;
                // Learn a machine
                calibration.Learn(words, labels);
                // Obtain class predictions for each sample
                int[] predicted = svm.Decide(words);
                int[] expected = new int[words.Length];
    
    
                double correct = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    expected[i] = labels[i];
                    predicted[i] = svm.Decide(words[i]);
                    if (svm.Decide(words[i]) == labels[i])
                    {
                        correct++;
                    }
    
                }
                string Accurecy = "SMO Accurecy = " + (correct / predicted.Length).ToString() + Environment.NewLine; // ori
                
