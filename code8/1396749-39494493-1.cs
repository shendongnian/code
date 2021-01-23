    // Nested models will have two states each
    int[] states = new int[] { 2, 2 };
    
    // Creates a new Hidden Markov Model Sequence Classifier with the given parameters
    HiddenMarkovClassifier classifier = new HiddenMarkovClassifier(classes, states, symbols);
    
    // Create a new learning algorithm to train the sequence classifier
    var teacher = new HiddenMarkovClassifierLearning(classifier,
    
        // Train each model until the log-likelihood changes less than 0.001
        modelIndex => new BaumWelchLearning(classifier.Models[modelIndex])
        {
            Tolerance = 0.001,
            Iterations = 0
        }
    );
    
    // Train the sequence classifier using the algorithm
    double likelihood = teacher.Run(inputs, outputs);
    // Classify the sequences as belonging to one of the classes:
    int output = classifier.Decide(new int[] { 1,0,0,1 }) // output should be 1
