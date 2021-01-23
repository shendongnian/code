    // in class NeuralNet
    public void AddLayer(int numNeurons)
    {
      Layer layer = new Layer(numNeurons,
                              n_layers.Count(),
                              (n_layers.Count > 0)
                                ? n_layer[n_layers.Count-1]
                                : null);
      n_layers.Add(layer);
    }
