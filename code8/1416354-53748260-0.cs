    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace CreateClassesObjs
    {
        class Course
        {
            private string ClassName { get; set; }
            public void setName(string selection)
            {
                ClassName = selection;
            }
    
            public override string ToString()
            {
                return ClassName.ToString();
            }
        
        }
    }
