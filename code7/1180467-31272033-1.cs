    public interface IGenerator
    {
        string GeneratePdf();
    }
    public class Foo1 : IGenerator
    {
        public Foo1() { }
        public string GeneratePdf() { return "Red"; }
    }
    public class Foo2 : IGenerator
    {
        public Foo2() { }
        public string GeneratePdf() { return "Blue"; }
    }
    IGenerator pdfTemplate;
    long dealerAccountId = 121;  //247
    
    switch(dealerAccountId)
    {
       case 247:
           pdfTemplate = new Foo2();
           break;
       default:
           pdfTemplate = new Foo1();
           break;
    }
    
    string color = pdfTemplate.GeneratePdf();
