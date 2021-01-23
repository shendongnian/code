    class GenericModel
    {
        public virtual string DoStuff<TType>(IEnumerable<TType> input)
            where TType : GenericModel
        {
            return null;
        }
    }
    
    class BasicModel : GenericModel
    {
        public int id { get; set; }
    }
    
    class ChildModel : BasicModel
    {
        public override string DoStuff<TType>(IEnumerable<TType> input)
        {
            var castedInput = input.Cast<BasicModel>();
    
            foreach (var data in castedInput)
            {
                var foo = data.id;
                //Do stuff with foo
            }
            //Do more stuff
    
            return null;
        }
    }
