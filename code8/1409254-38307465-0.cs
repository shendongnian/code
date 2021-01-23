    class Program
    {
        static void Main(string[] args)
        {
            List<Expression>  expressions =  new List<Expression>();
            Expression <Func<string,int>> func = a => a.Length;
            
            expressions.Add(func);
            foreach (var expression in expressions)
            {
                LambdaExpression lmdExpression = expression  as LambdaExpression;
                if (lmdExpression!=null)
                {
    
                    //get  all params 
                     List<string>   paramsList  = new List<string>();
                    foreach (var parameterExpression in lmdExpression.Parameters)
                    {
                        paramsList.Add(parameterExpression.Type.ToString());  
                    }
                    var returnedType = lmdExpression.ReturnType.ToString(); 
                    //and  here you can use a big switch  to  invoke your needed expression 
    
    
    
    
                }
            }
    
    
            Console.ReadLine(); 
    
        }
    }
