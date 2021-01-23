     public static string CodeElementAsTypeFullName(EnvDTE80.CodeElement2 element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (element.Kind == vsCMElement.vsCMElementClass
                || element.Kind == vsCMElement.vsCMElementEnum
                || element.Kind == vsCMElement.vsCMElementStruct)
                return element.FullName;
            else
                return ((dynamic)element).Type.AsFullName;
        }
    protected List<IFileLine> FlattenElement(EnvDTE80.CodeElement2 element)
    {            
            List<IFileLine> flatProps = new List<IFileLine>();          
            try
            {
                string varType = CodeElementAsTypeFullName(element);               
                switch (element.Kind)
                {
                    case vsCMElement.vsCMElementVariable:
                    case vsCMElement.vsCMElementProperty:
                    {
                        EnvDTE80.CodeElement2 defined = null;
                        ///this is API, basically  a collection of all the files in the solution with all class/enum/stuct defs parsed out into collections.
                        foreach (SquishFile file in this.solutionFiles)
                        {
                            //next line goes through each solution file one by one to figure out if the file defines the class/enum/struct definition.
                            defined = file.ContainsCodeElement(varType);
                            if (defined != null)
                                break;
                        }
                        if (defined != null)
                        {
                            if (defined.Kind == vsCMElement.vsCMElementClass
                                            || defined.Kind == vsCMElement.vsCMElementStruct
                                            || defined.Kind == vsCMElement.vsCMElementEnum)
                                        //THE ITEM IS DEFINED LOCALLY!    
                        }else
                          //the item is a reference
             }
            }
        }
