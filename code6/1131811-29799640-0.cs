    public enum ProcessType { 
        Multiplication,
        Addition,
        Division,
        Subtraction
    }
    public int Process(ProcessType processType, int a, int b)
    {
        switch (processType)
        { 
            case ProcessType.Addition:
                return SumClass(a, b);
            case ProcessType.Multiplication:
                return MultClass(a, b);
             // ...
        }
    }
