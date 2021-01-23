        class PregnancyIndividual : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                PregnancyIndividual ind1 = (PregnancyIndividual)a;
                PregnancyIndividual ind2 = (PregnancyIndividual)b;
                int res = 1;
                double fitness1 = ind1.FitnessCalculator.calculateFitness(ind1);
                double fitness2 = ind2.FitnessCalculator.calculateFitness(ind2);
                if (fitness1 > fitness2)
                {
                    return -1;
                }
                if (fitness1 == fitness2)
                {
                    return 0;
                }
                return res;
            }    
        }
