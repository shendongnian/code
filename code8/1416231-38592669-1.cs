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
    protected void FlattenElement(EnvDTE80.CodeElement2 element)
    {                        
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
         public class SquishFile
    {        
        public ConcurrentBag<CodeClass> ClassDefinitions = new ConcurrentBag<CodeClass>();
        public ConcurrentBag<CodeEnum> EnumDefinitions = new ConcurrentBag<CodeEnum>();
        public ConcurrentBag<CodeStruct> StructDefinitions = new ConcurrentBag<CodeStruct>();
        protected ProjectItem _projectItem;
        public ProjectItem ProjectItem { get { return _projectItem; } }
        public SquishFile(ProjectItem projectItem)
        {
            if (projectItem.FileCodeModel == null)
                throw new Exception("Cannot make a squish file out of a project item with no FileCodeModel!");
            _projectItem = projectItem;
            foreach (EnvDTE80.CodeElement2 ele in projectItem.FileCodeModel.CodeElements)
                Discovery(ele);
        }
       
        public EnvDTE80.CodeElement2 ContainsCodeElement(string fullName)
        {
            foreach(EnvDTE80.CodeElement2 ele in ClassDefinitions)
                if (ele.FullName.Equals(fullName))
                    return ele;
            foreach (EnvDTE80.CodeElement2 ele in EnumDefinitions)
                if (ele.FullName.Equals(fullName))
                    return ele;
            foreach (EnvDTE80.CodeElement2 ele in StructDefinitions)
                if (ele.FullName.Equals(fullName))
                    return ele;
            return null;
        }
        protected void Discovery(EnvDTE80.CodeElement2 element)
        {
            if (element.IsCodeType && element.Kind == vsCMElement.vsCMElementClass)
                this.ClassDefinitions.Add(element as EnvDTE80.CodeClass2);
            else if (element.IsCodeType && element.Kind == vsCMElement.vsCMElementEnum)
                this.EnumDefinitions.Add(element as EnvDTE.CodeEnum);
            else if (element.IsCodeType && element.Kind == vsCMElement.vsCMElementStruct)
                this.StructDefinitions.Add(element as EnvDTE80.CodeStruct2);
            foreach (EnvDTE80.CodeElement2 ele in element.Children)
                Discovery(ele);
        }
    }
