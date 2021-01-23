    // in class Layer
    public Layer(int numNeurons,
                 int numLayer,
                 Layer prevLayer = null)
    {
      for (int i = 0; i <= numNeurons; ++i)
      {
        Neuron neuron = new Neuron(i);
        n_neurons.Add( neuron );
      }
      if (prevLayer != null)
      {
        for(int i=0; i<prevLayer.n_neurons.Count(); ++i)
        {
          for(int j=0; j<n_neurons.Count(); ++j)
          {
            prevLayer.n_neurons[i].outputWeights.Add(
              new Connection(randomWeight(), randomWeight() ) );
          }
        }
      }
    }
