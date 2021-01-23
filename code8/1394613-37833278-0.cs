        public abstract class ABC
        {
            private string data = "hi ";
            protected ABC(string myString)
            {
                data += myString;
            }
	
			public string PropToReturnValuePassedInCtor{ get { return data; } }
        }
        public class XYZ: ABC
        {
            public string abc = "";
			
            public XYZ(string myString)
                : base(myString)
            {
                abc = base.PropToReturnValuePassedInCtor;
            }
        }
        var t = new XYZ("567");
		Console.Write(t.abc); //hi 567 
