        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Threading;
        namespace ConsoleApplication8
       {
        class Program
         {
           static Random random = new Random();
            static void Main(string[] args)
            {
            Population p;
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            int population = 100;
            p = new Population(file, population);
       
            int gen = 0;
            while (gen <= 1000)
            {
                p.evolve(file);
                ++gen;
            }
            file.Close();
        }
        public static double GetRandomNumber(double min, double max)
        {
            return (random.NextDouble() * (max - min)) + min;
            //return random.NextDouble() *random.Next(min,max);
        }
        //Class Genotype
        public class Genotype
        {
            public int[] genes;
            public Genotype()
            {
                this.genes = new int[2];
                for (int i = 0; i < genes.Length; i++)
                {
                    this.genes[i] = (int)GetRandomNumber(-500.0, 500.0);
                }
            }
            public void mutate()
            {
                //5% mutation rate
                for (int i = 0; i < genes.Length; i++)
                {
                     if (GetRandomNumber(0.0, 100) < 5)
                     {
                        //Random genernd = new Random();
                        this.genes[i] = (int)GetRandomNumber(0.0, 256.0);
                     }
                }
            }
        }
        static Genotype crossover(Genotype a, Genotype b)
        {
            
            Genotype c = new Genotype();
            for (int i = 0; i < c.genes.Length; i++)
            {
                //50-50 chance of selection
                if (GetRandomNumber(0.0, 1) < 0.5)
                {
                    c.genes[i] = a.genes[i];
                }
                else
                {
                    c.genes[i] = b.genes[i];
                }
            }
            return c;
        }
        //Class Phenotype
        public class Phenotype
        {
            double i_x;
            double i_y;
            public Phenotype(Genotype g)
            {
                this.i_x = g.genes[0];
                this.i_y = g.genes[1];
            }
            public double evaluate(System.IO.StreamWriter file)
            {
                double fitness = 0;
                //fitness -= i_x + i_y;
                fitness -= (i_x*Math.Sin(Math.Sqrt(Math.Abs(i_x)))) + i_y*(Math.Sin(Math.Sqrt(Math.Abs(i_y))));
                file.WriteLine(fitness);
                return fitness;  
            }
        }
        //Class Individual
        public class Individual : IComparable<Individual>
        {
            public Genotype i_genotype;
            public Phenotype i_phenotype;
            double i_fitness;
            public Individual()
            {
                this.i_genotype = new Genotype();
                this.i_phenotype = new Phenotype(i_genotype);
                this.i_fitness = 0.0;
            }
            public void evaluate(System.IO.StreamWriter file)
            {
                this.i_fitness = i_phenotype.evaluate(file);
            }
            int IComparable<Individual>.CompareTo(Individual objI)
            {
                Individual iToCompare = (Individual)objI;
                if (i_fitness < iToCompare.i_fitness)
                {
                    return -1; //if I am less fit than iCompare return -1
                }
                else if (i_fitness > iToCompare.i_fitness)
                {
                    return 1; //if I am fitter than iCompare return 1
                }
                return 0; // if we are equally return 0
            }
        }
        public static Individual breed(Individual a, Individual b)
        {
            Individual c = new Individual();
            c.i_genotype = crossover(a.i_genotype, b.i_genotype);
            c.i_genotype.mutate();
            c.i_phenotype = new Phenotype(c.i_genotype);
            return c;
        }
        
        //Class Population
        public class Population
        {
            Individual[] pop;
            //int populationNum = 100;
            public Population(System.IO.StreamWriter file, int populationNum)
            {
                this.pop = new Individual[populationNum];
                for (int i = 0; i < populationNum; i++)
                {
                    this.pop[i] = new Individual();
                    this.pop[i].evaluate(file);
                }
                Array.Sort(pop);
            }
            public void evolve(System.IO.StreamWriter file)
            {
                Individual a = select(100);
                Individual b = select(100);
                //breed the two selected individuals
                Individual x = breed(a, b);
                //place the offspring in the lowest position in the population, thus  replacing the previously weakest offspring
                this.pop[0] = x;
                //evaluate the new individual (grow)
                x.evaluate(file);
                //the fitter offspring will find its way in the population ranks
                Array.Sort(pop);
            }
            Individual select(int popNum)
            {
                //skew distribution; multiplying by 99.999999 scales a number from 0-1 to  0-99, BUT NOT 100
                //the sqrt of a number between 0-1 has bigger possibilities of giving us a smaller number
                //if we subtract that squares number from 1 the opposite is true-> we have bigger possibilities of having a larger number
               int which = (int)Math.Floor(((float)popNum - 1E-6) * (1.0 - Math.Pow(GetRandomNumber(0.0, 1.0), 2)));
               return pop[which];
            }
        }
    }
}
