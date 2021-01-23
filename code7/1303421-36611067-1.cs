            var conf = new System.Composition.Hosting.ContainerConfiguration();
            conf.WithAssembly(Assembly.GetExecutingAssembly());
            var container = conf.CreateContainer();
            var hwWriter = new HelloWorldWriter();
            container.SatisfyImports(hwWriter);
            Console.WriteLine(hwWriter.Write);
            Console.ReadLine();
