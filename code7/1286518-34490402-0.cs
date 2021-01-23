    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    //add reference for System.Data.Entity
    using System.Data.Objects;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var OverDate = new ObjectParameter("OverDate", (DateTime)DateTime.Now);
                DateTime? convertedDate = (DateTime?)OverDate.Value;
            }
        }
    }
    ​
