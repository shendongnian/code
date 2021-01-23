    public interface IPrintable
    {
        public void Print();
    }
    
    public class PrintToConsole : IPrintable
    {
        public void Print()
        {
            //Print to console
        }
    }
    
    public class PrintToPrinter : IPrintable
    {
        public void Print()
        {
            //Print to printer
        }
    }
    
    
    public void DoSomething(IPrintable printer)
    {
         ...
         printer.Print();
    }
    
    ...
    
    if(printToConsole)
        DoSomething(new PrintToConsole());
    else
        DoSomething(new PrintToPrinter());
        
