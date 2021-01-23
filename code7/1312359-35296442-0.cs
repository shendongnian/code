    public double WrapFunction(out int ncalls, out double FuncValue, double[] inputArr, Tuple<List<double>, List<double>> arguments)
    {
        int calls = 0;//Number_of_FunctionEvaluations
        // MASTER class instance  
        Master prismpy = new Master();
        calls += 1;//Number_of_FunctionEvaluations_Increment
        ncalls = calls;//Return_Number_of_FunctionEvaluations
        return prismpy.WminObjectivefunction(inputArr, arguments.Item1, arguments.Item2);//Return_FunctionValuation
    }
