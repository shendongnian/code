    string mystring = "A:\"" + AddSpace(var1) + AddSpace(var2) + var3 + "\"";
                
            public string AddSpace(String var)
            {
                 return var == null ? "" : var + " ";
            }
