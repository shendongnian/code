    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityLibrary;
    namespace SimpleClient {
	    class Program {
		    static void Main(string[] args) {
                var entity = new ManagedEntity();
			    for (int i = 0; i < entity.GetVec().Length; i++ )
                    Console.WriteLine(entity.GetVec()[i]);
       	    }
	    }
    }
