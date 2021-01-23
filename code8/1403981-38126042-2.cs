    Dictionary<string, string> result = List2.ToDictionary(s => s, 
                           s =>
                           {
                               string v =  List1.FirstOrDefault(f => f.EndsWith(s));
                               if (v == null)
                               {
                                   ThirdPartyRepackVariables.unmatchedPaths.Add(s);
                                   return s;
                               }
                               ThirdPartyRepackVariables.pathsUpdated++;
                               return v;
                           });
