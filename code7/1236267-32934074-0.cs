      static IEnumerable<string> ReturnString(Obj val)
            {
                foreach (Obj node in val.Childs)
                    yield return ConvertToString(node);
            }
    
            static string ConvertToString(Obj val)
            {
                switch(val.Name)
                {
                    case "Operator":
                        {
                            return string.Format("({0} {1} {2})", val.Childs[0].Name, val.Value, val.Childs[0].Value);
                        }
                    case "Method":
                        {
                            IEnumerable<string> coll = ReturnString(val);
                            StringBuilder final = new StringBuilder();
                            final.Append("(");
    
                            IEnumerator<string> e = coll.GetEnumerator();
                            e.MoveNext();
                            final.Append(string.Format("{0}", e.Current, val.Value));
    
                            while (e.MoveNext())
                            {
                               final.Append(string.Format(" {0} {1}", val.Value, e.Current));
                            }
    
                            final.Append(")");
    
    
                            return final.ToString();
                        }
                    case "Name":
                        return  Convert.ToString(val.Value);
               }
               return "-";
            }
