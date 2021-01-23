    var numberOfCities = 20;
    var selection = new EliteSelection();
    var crossover = new OrderedCrossover();
    var mutation = new ReverseSequenceMutation();
    var fitness = new TspFitness(numberOfCities, 0, 1000, 0, 1000);
    var chromosome = new TspChromosme(numberOfCities);
    var population = new Population (100, 200, chromosome);
    
    var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
    ga.Termination = new GenerationNumberTermination(100);
    
    Console.WriteLine("GA running...");
    ga.Start();
    
    Console.WriteLine("Best solution found has {0} fitness.", ga.BestChromosome.Fitness);
