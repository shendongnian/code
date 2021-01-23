    public override string DoStuff<TType>(IEnumerable<TType> input)
        where TType : BasicModel
        {
            foreach(var data in input)
            {
               var foo = data.id;
               //Do stuff with foo
            }
        }
