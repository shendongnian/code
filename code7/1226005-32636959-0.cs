    public class EquationGenerator 
            {
                EquationTerm[] LeftTerms;
                EquationTerm[] RightTerms;
    
                void Start()
                {
                    //Initialize both side with a random number of terms
                    LeftTerms = InitializeArray(new Random().Next(1, 6));
                    RightTerms = InitializeArray(new Random().Next(1, 6));
                }
    
                EquationTerm[] InitializeArray(int length)
                {
    
                    EquationTerm[] array = new EquationTerm[length];
                    array[0] = new EquationTerm(new Random().Next(1, 10));
                    for (int i = 1; i < length; ++i)
                    {
                        array[i] = new EquationTerm(new Random().Next(1, 10), new Random().Next(1, 5), true);
                    }
    
                    return array;
                }
            }
