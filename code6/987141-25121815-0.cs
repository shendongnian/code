        class EntityA
        {
            public int ID { get; set; }
        }
        class EntityB
        {
            public int ID { get; set; }
            public EntityA EntityA { get; set; }
        }
        static void Main( string[] args )
        {
            int entityAIdToTest = 2;
            // existing expression to reuse
            Expression<Func<EntityA, bool>> aPredicate = ( EntityA a ) => a.ID == entityAIdToTest;
            //Expression<Func<EntityA, bool>> aPredicate = ( EntityA a ) => a.ID % 2 == 1;
            // build EntityB predicate dynamically
            // parameter
            ParameterExpression parmExp = Expression.Parameter( typeof( EntityB ), "b" );
            // property expression b.EntityA
            MemberExpression propExp = Expression.Property( parmExp, "EntityA" );
            // invoke aPredicate on b.EntityA value
            var callExp = Expression.Invoke( aPredicate, propExp );
            // wrap in a lambda expression, compile, cast to appropriate type
            var bPredicate = ( Func<EntityB, bool> )Expression.Lambda( callExp, parmExp ).Compile();
            // test data
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
            foreach( var b in list.Where( bPredicate ) )
            {
                Console.WriteLine( "{0}/{1}", b.ID, b.EntityA.ID );
            }
            Console.ReadLine();
        }
