    class G<T> {
      public class C { }
      public void M(C arg) { }
    }
    class G2<T> : G<T> { }
    
    string s1 = typeof(G<>).GetGenericArguments()[0].FullName; 
    // T in G<T>: generic parameter
    string s2 = typeof(G<>).GetMethod("M").GetParameters()[0].ParameterType.FullName; 
    // check out the IL, it is G`1/C<!T> (not generic type definition) 
    // Related topic, see this 
    string s3 = typeof(G2<>).BaseType.FullName; 
    // base type of G2<>, which is not generic type definition either
    // it equals to typeof(G<>).MakeGenericType(typeof(G2<>).GetGenericArguments()[0])
