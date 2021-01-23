    static void Main( string[] args )
    {
        var list = new List<EntityB>()
        {
            new EntityB()
            {
                ID = 11,
                EntityA = new EntityA() { ID = 1 }
            },
            new EntityB()
            {
                ID = 22,
                EntityA = new EntityA() { ID = 2 }
            },
            new EntityB()
            {
                ID = 33,
                EntityA = new EntityA() { ID = 3 }
            },
        };
        var filteredResults = list.Where( 
            SubPredicate<EntityA, EntityB>( 
                a => a.ID % 2 == 1, 
                b => b.EntityA )
                .Compile() );
        foreach( var b in filteredResults )
        {
            Console.WriteLine( "{0}/{1}", b.ID, b.EntityA.ID );
        }
        Console.ReadLine();
    }
