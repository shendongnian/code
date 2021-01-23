    public abstract class ObjectBase
        {
            //The IsDirty Property
            protected bool _isDirty;
            public bool IsDirty
            {
                get { return _isDirty; }
                set { _isDirty = value; }
            }
    
            /// <summary>
            /// Using this item as the root, walk the tree to get all dirty objects
            /// </summary>
            /// <returns>IEnumerable<ObjectBase></returns>
            public IEnumerable<ObjectBase> GetDirtyObjects()
            {
                var dirtyObjects = new List<ObjectBase>();
                WalkTree(
                o =>
                {
                    if (o.IsDirty)
                        dirtyObjects.Add(o);
    
                    return false; // can return true to stop walk on first object
                });
    
                return dirtyObjects;
            }
    
            ///Sets all DirtyObjects in the tree to clean
            public void CleanTree()
            {
                WalkTree(
                o =>
                {
                    o.IsDirty = false;
                    return false; // can return true to stop walk on first object
                });
    
            }
    
            //Accepts a function to be executed, and any properties that you might want to be excluded
            //in this instance the function we'll be using is getting the dirty objects(above)
            public void WalkTree(Func<ObjectBase, bool> walkSnippet, IEnumerable<string> exemptProperties = null)
            {
                //Create a list of visited objects to prevent looking at the same objects twice
                List<ObjectBase> visited = new List<ObjectBase>();
                
                //Take into consideration any exemptions via property name
                List<string> exemptions = new List<string>();
                if (exemptProperties != null)
                    exemptions = exemptProperties.ToList();
    
                Walk(this, visited, walkSnippet, exemptions);
            }
    
            //Does the actual walking of the tree, looking through all the properties
            //on the class, checking to see if that property is of the type, or an 
            //IEnumerable of ObjectBase
            private void Walk(ObjectBase obj, List<ObjectBase> visited, Func<ObjectBase, bool> walkSnippet, IEnumerable<string> exemptions)
            {
                //if you have already checked this object, check it
                if (obj != null && !visited.Contains(obj))
                {
                    //add to the visited list
                    visited.Add(obj);
                    //invoke the walk snippet declared in GetDirtyObjects
                    walkSnippet.Invoke(obj);
                   
                    //Loop through all the properties that implement ObjectBase
                    //or are an IEnumerable<ObjectBase>, that aren't exempt
                    foreach (var property in ReflectionHelper.GetTreeProperties(obj, true).Where(x => !exemptions.Contains(x.Name)))
                    {
                        //If it's a single object, recurse this method
                        if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                        {
                            Walk((ObjectBase)property.GetValue(obj), visited, walkSnippet, exemptions);
                        }
                        else
                        {
                            //if it's an IEnumerable property, recurse this method
                            //over the collection
                            var objEnumerable = (IEnumerable<ObjectBase>)property.GetValue(obj);
                            if (objEnumerable != null)
                            {
                                foreach (var nestedObj in objEnumerable)
                                {
                                    Walk((ObjectBase)nestedObj, visited, walkSnippet, exemptions);
                                }
                            }
                        }
                    }
                }
            }
        }
