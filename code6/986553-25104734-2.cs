    int main() 
    {
        double A = 12.2345; //seed
        double prevResult = 1; //You can assign any value here
        double result;
        double intPart;
        
        //This will give you 10 uniform distributed numbers
        for(unsigned i = 0; i < 10; ++i)
        {
            double r = A * prevResult;
            
            result = modf(r, &intPart); // To get rid of integer part
    
            prevResult = result;
    
            cout<<"result "<<i<<" = "<<result<<endl;
        }
    }
