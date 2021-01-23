    public class Composer
    {
        List<INodeActor> _actors = new List<INodeActor>();
    
        public void AddActor(INodeActor actor)
        {
            _actors.Add(actor);
        }
    
        public void Process(CodeTree tree)
        {
             foreach (CodeTree node in tree.Codes)
             {
                 var actors = _actors.Where(x => x.CanAct(node));
                 if (!actors.Any())
                     throw new InvalidOperationException("Got no actor for " + node.GetType());
    
                 foreach (var actor in actors)
                     actor.Invoke(node);
             }
        }
    }
