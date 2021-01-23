            Foo f = new Foo();
            f.Name = "First Foo";
            System.Diagnostics.Debug.WriteLine(f.Name);
            Bar b = new Bar(f);
            System.Diagnostics.Debug.WriteLine(b.MyFoo.Name);
            b.MyFoo.Name = "Renaming Bar Name";
            System.Diagnostics.Debug.WriteLine(f.Name);
            System.Diagnostics.Debug.WriteLine(b.MyFoo.Name);
