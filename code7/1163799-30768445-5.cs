    public class WhateverThread : MyThreadImplementation
    {
        public override void ConcreteMethod()
        {
            // manipulate the private list
            list.Add(new YourObject());
        }
    }
