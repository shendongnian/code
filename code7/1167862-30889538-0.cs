    object obj = "Int32";            // As a compile-time constant string, this will be interned.
    string str1 = "Int32";           // This is also interned, so has the same reference as obj
    string str2 = typeof(int).Name;  // Same contents as str1, but a different reference 
                                     // (created at runtime, so it wasn't interned)
    Console.WriteLine(obj == str1);  // Reference comparison: true because the references are the same
    Console.WriteLine(str1 == str2); // String comparison: true because the string contents are the same.
    Console.WriteLine(obj == str2);  // Reference comparison: false because the references different.
