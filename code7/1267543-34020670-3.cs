    int max_factorial (int x, int x_fact, int y, int y_fact)
    {
        int A=1,B=1,F=0,product=1,sum=0;
        
        if (x_fact == y_fact) return (x>y?x:y);
        
        if (x_fact > y_fact)
        {
            A = x; B = y; F = x_fact-y_fact;
        }
        else
        {
            A = y; B = x; F = y_fact-x_fact;
        }
        for (int k=0; k<F; k++)
        {
            try
            {
                for (int i=1; i<A; i++)
                {
                    // multiplication in terms of addition
                    // P * i = P + P + .. P } i times
                    sum = 0; for (int p=0; p<i; p++) sum += product;
                    product = product + sum;
                    if (product > B) return A;
                }
            }
            catch (OverflowException e)
            {
                return A;
            }
        }
        
        return B;
    }
