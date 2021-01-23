    public interface IBlabla {
	    string bla();
    }
    public class BlaBla : IBlabla 
    {
        public string bla() {
            return "implicit";
        }
    
        string IBlabla.bla()
        {
            return "EXPLICIT";
        }
    }
	BlaBla Myclass = new BlaBla();    
	Console.WriteLine(Myclass.bla()); // implicit
	Console.WriteLine(((IBlabla)Myclass).bla()); // EXPLICIT
