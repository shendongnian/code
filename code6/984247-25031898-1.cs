    internal class ChildHolder
    {
        public Child TheChild {get; private set;} // get the payload child
        public ChildHolder Parent {get;set;} // store information about parent
    
        public ChildHolder(Child child)
        {        
           TheChild = child;
        }
        public virtual void AddChild(ChildHolder childHolder)
        {
            TheChild.Add(childHolder.TheChild); // store children in original child object
            childHolder.Parent = this; // and pass my parent information to childs holder
        }
    }
    
