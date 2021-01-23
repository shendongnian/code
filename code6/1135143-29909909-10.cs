       using ( TestContext context = new TestContext( ) )
        {
            context.Database.Log = Console.WriteLine;
            ParentEntity p1 = new ParentEntity( );
            p1.Property1 = "Value of P1";
            p1.Property2 = "Value of P2";
            ChildEntity c1 = new ChildEntity( );
            c1.Value1 = "V1";
            c1.Value2 = "V2";
            p1.child = c1;
            context.Parent.Add( p1 );
            context.SaveChanges( );
            myEntity = p1.Id;
        }
        using( TestContext context = new TestContext() )
        {
            context.Database.Log = Console.WriteLine;
            ParentEntity p = context.Parent.Where( x => x.Id == myEntity ).FirstOrDefault( );
            p.Property1 = "Changed";
            p.Property2 = "Value of P2";
            context.SaveChanges( );
        }
