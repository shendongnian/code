    namespace UnityMutliTest
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        using Microsoft.Practices.Unity;
    
        class Program
        {
            static void Main(string[] args)
            {
                IUnityContainer container = new UnityContainer();
    
                container.RegisterType<IWriter, FileWriter>("file");
                container.RegisterType<IWriter, DbWriter>("db");
    
                container.RegisterType<IWriterSelector, WriterSelector>();
    
                var writerSelector = container.Resolve<IWriterSelector>();
    
                var writer = writerSelector.SelectWriter("FILE");
    
                writer.Write("Write me data");
    
                Console.WriteLine("Success");
    
                Console.ReadKey();
            }
        }
    
        interface IWriterSelector
        {
            IWriter SelectWriter(string output);
        }
    
        class WriterSelector : IWriterSelector
        {
            private readonly IEnumerable<IWriter> writers;
    
            public WriterSelector(IWriter[] writers)
            {
                this.writers = writers;
            }
    
            public IWriter SelectWriter(string output)
            {
                var writer = this.writers.FirstOrDefault(x => x.CanWrite(output));
    
                if (writer == null)
                {
                    throw new NotImplementedException($"Couldn't find a writer for {output}");
                }
    
                return writer;
            }
        }
    
        interface IWriter
        {
            bool CanWrite(string output);
    
            void Write(string data);
        }
    
        class FileWriter : IWriter
        {
            public bool CanWrite(string output)
            {
                return output == "FILE";
            }
    
            public void Write(string data)
            {
            }
        }
    
        class DbWriter : IWriter
        {
            public bool CanWrite(string output)
            {
                return output == "DB";
            }
    
            public void Write(string data)
            {
            }
        }
    }
