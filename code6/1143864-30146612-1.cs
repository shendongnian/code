            Foo f = new Foo();
            f.Name = "First Foo";
            Console.WriteLine(f.Name);
            Bar b = new Bar(f);
            Console.WriteLine(b.MyFoo.Name);
            b.MyFoo.Name = "Renaming Bar Name";
            Console.WriteLine(f.Name);
            Console.WriteLine(b.MyFoo.Name);
