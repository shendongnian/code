        static void Main(string[] args)
        {
            TestTransform("XSLTFile1.xslt", "XMLFile1.xml", "Result1.xml");
        }
        public static void TestTransform(string xsltFile, string inputFile, string outputFile)
        {
            var xslt = new FileInfo(xsltFile);
            var input = new FileInfo(inputFile);
            var output = new FileInfo(outputFile);
            // Compile stylesheet
            var processor = new Processor(false);
            var compiler = processor.NewXsltCompiler();
            var executable = compiler.Compile(new Uri(xslt.FullName));
            using (var inputStream = input.OpenRead())
            {
                var transformer = executable.Load();
                transformer.SetInputStream(inputStream, new Uri(input.DirectoryName));
                var serializer = new Serializer();
                using (var resultStream = output.OpenWrite())
                {
                    serializer.SetOutputStream(resultStream);
                    transformer.Run(serializer);
                }
            }
            
        }
    }
