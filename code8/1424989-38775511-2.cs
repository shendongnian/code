      class Program
    {
        static void Main(string[] args)
        {
            string template = "Hello @Model.Types, welcome to RazorEngine!";
            var result =
                Engine.Razor.RunCompile(template, "templateKey", null, new TemplateConstants());
            Console.WriteLine(result);
        }
    }
    public class TemplateConstants
    {
        public readonly string Types = "Some type";
        public readonly string Purpose = "«Purpose»";
        public readonly string FirstName = "«FirstName»";
    }
