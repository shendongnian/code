    class RandomNumberGenerator
    {
    public:
        RandomNumberGenerator()
        {
            uniformPrevResult = 1;
            uniformResult = 0;
            uniformIntPart = 0;
        }
    
        double generateUniformNumber(double seed)
        {
            double r = seed * uniformPrevResult;
            
            uniformResult = modf(r, &uniformIntPart); // To get rid of integer part
    
            uniformPrevResult = uniformResult;
    
            return uniformResult;
        }
    
        double generateNormalNumber(double seed)
        {
            double uniformSum = 0;
    
            for(unsigned i = 0; i < 12; ++i)
            {
                uniformSum += generateUniformNumber(seed);
            }
    
            double normalResult = uniformSum - 6;
    
            return normalResult; // 6 is a magic number
        }
    
    private:
        double uniformPrevResult;
        double uniformResult;
        double uniformIntPart;
    };
    
    int main() 
    {
        const double seed = 12.2345;
    
        RandomNumberGenerator rndGen;
    
        for(unsigned i = 0; i < 100; ++i)
        {
            double newNormalNumber = rndGen.generateNormalNumber(seed);
    
            cout<<"newNormalNumber = "<<newNormalNumber<<endl;
        }
        
        return 0;
    }
