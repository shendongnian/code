    // The following removes generics from your code
    abstract class AnalysisResult {
    }
    
    interface IAnalyzer {
        AnalysisResult PerformAction(string input);
    }
    
    class ConcreteAnalysisResult : AnalysisResult {
        public int SpecificProperty { get; set; }
    }
    
    class ConcreteAnalyzer : IAnalyzer {
        public AnalysisResult PerformAction(string input) {
            return new ConcreteAnalysisResult() { SpecificProperty = input.Length };
        }
    }
    // Here is the magic that lets you process results of specific types without generics
    public static void main(string[] args) {
        var analyzer = new ConcreteAnalyzer();
        dynamic res = analyzer.PerformAction(input);
        ProcessResult(res); // This gets dispatched dynamically to the correct overload
    }
    private static void ProcessResult(ConcreteAnalysisResult cr) {
        Console.WriteLine(cr.SpecificProperty);
    }
    private static void ProcessResult(SomeOtherConcreteAnalysisResult cr) {
        Console.WriteLine(cr.AnoterhSpecificProperty);
    }
    private static void ProcessResult(AnalysisResult cr) {
        // Throw an error: unexpected result type
    }
