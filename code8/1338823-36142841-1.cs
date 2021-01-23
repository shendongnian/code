    IEnumerable<StatusInt> StatusInts
    {
       get
       {
           if(this.OptionIsSelected)
           {
               return GenerateOptions(this.Option);
           }
           else 
           {
                return Enumerable.Empty<StatusInt>();
           }
       }
    }
