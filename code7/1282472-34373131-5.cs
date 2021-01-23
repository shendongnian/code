    Symbol a = new Symbol();
    Symbol b = new Symbol("A");
    Symbol c = new Symbol("A");
    Symbol d = c;
    var dict = new Dictionary<object, int>() { { c, 42 } };
    Symbol e = Symbol.For("X");
    Symbol f = Symbol.For("X");
    Symbol g = Symbol.For("Y");
    Console.WriteLine(a == b); // false
    Console.WriteLine(b == c); // false
    Console.WriteLine(c == d); // true
    Console.WriteLine(dict[d]); // 42
    Console.WriteLine(e == f); // true
    Console.WriteLine(f == g); // false
    Console.WriteLine(Symbol.For("X") == e); // true
    Console.WriteLine(Symbol.KeyFor(e) == "X"); // true
    Console.WriteLine(Symbol.Unscopables.Description); // Symbol.unscopables
