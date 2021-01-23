    <#
    var @object = new SampleClass(this); // Pass 'this' (TextTransformation) to the constructor
    @object.SayHello();
    #>
    <#+
    public class SampleClass // This is actually a nested child class in T4 templates
    {
        private readonly TextTransformation _writer;
        public SampleClass(TextTransformation writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");
            _writer = writer;
        }
        public void SayHello()
        {
            _writer.WriteLine("Hello");
        }
    }
    #>
