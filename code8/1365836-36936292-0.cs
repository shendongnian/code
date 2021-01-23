    public interface IGenotype
    {
       //some code...
    }
    
    public class Genotype : IGenotype
    {
        // ... some code
    }
    
    public class Individual 
    {
        // Here, instead of depending on a implementation you can inject the one you want
        private readonly IGenotype genotype; 
    
        // In your constructor you pass the implementation 
        public Individual(IGenotype genotype)
        {
            this.genotype = genotype;  
        }
    }
    
    // Genotype implements IGenotype interface
    var genotype = Genotype();
    
    // So here, when creating a new instance you're injecting the dependecy.
    var person = Individual(genotype);
