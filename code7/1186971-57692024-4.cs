        static StandardKernel kernel;
        static void Main(string[] args)
        {
            kernel = new StandardKernel(new LoadModule());    
            var tests = kernel.GetAll<Test>();
            tests.ToList().ForEach(c => Console.WriteLine(c.Name));
            Console.WriteLine();
            Console.WriteLine(GetByType<T1>().Name);
            var z = GetByType<T1>();
            z.Name = "abc";           
            Console.WriteLine(z.Name);
            Console.WriteLine(GetByType<T1>().Name);
            Console.WriteLine();
            Console.WriteLine(GetByType<T2>().Name);
            var za = GetByType<T2>();
            za.Name = "abc";
            Console.WriteLine(za.Name);
            Console.WriteLine(GetByType<T2>().Name);
            Console.WriteLine();
            tests = kernel.GetAll<Test>();
            tests.ToList().ForEach(c => Console.WriteLine(c.Name));
            Console.WriteLine();
            Console.ReadKey();
            
        }
        static public T GetByType<T>()
        {
            return kernel.Get<T>();
        }
        public class LoadModule : NinjectModule
        {
            public override void Load()
            {    
                this.Bind<Test, T1>().To<T1>().InSingletonScope();
                this.Bind<Test>().To<T2>();
            }
        }
