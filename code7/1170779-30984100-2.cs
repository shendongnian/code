    class Program {
        public enum Field { A, B, C };
        public int a, b, c;
	    private static readonly Func<Program,int>[] Getter= new Func<Program,int>[3];
	    private static readonly Action<Program,int>[] Setter= new Action<Program,int>[3];
        public int this[Field f] {
            get {
                return Getter[(int)f](this);
            }
            set {
                Setter[(int) f](this, value);
            }
        }
        static Program() {
	    	var names = Enum.GetNames(typeof(Field));
            var pThis = Expression.Parameter(typeof(Program), "pThis");
	    	var pVal = Expression.Parameter(typeof(int), "pVal");
	    	for (var i = 0 ; i != names.Length ; i++) {
	    		var f = Expression.Field(pThis, names[i].ToLower());
	    	    Getter[i] = Expression.Lambda<Func<Program, int>>(f, pThis).Compile();
	    	    var a = Expression.Assign(f, pVal);
	    	    Setter[i] = Expression.Lambda<Action<Program,int>>(a, pThis, pVal).Compile();
	    	}
	    }
        public override string ToString() {
            return string.Format("a={0} b={1} c={2}", a, b, c);
        }
        private static void Main(string[] args) {
            var p = new Program();
            p.a = 123;
            p.b = 456;
            p.c = 789;
            Console.WriteLine(p);
            p[Field.A] = 234;
            p[Field.B] = 567;
            p[Field.C] = 890;
            Console.WriteLine(p);
            Console.WriteLine(p[Field.A]);
            Console.WriteLine(p[Field.B]);
            Console.WriteLine(p[Field.C]);
        }
    }
