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
                return null;
           }
       }
    }
