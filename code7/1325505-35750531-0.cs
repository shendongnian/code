    //Property is not primitive so recurse
                        if (fi.GetValue(obj) is IEnumerable)
                        {
                            //Object is IEnumerable, process each object separately
                            foreach (var o in (IEnumerable)fi.GetValue(obj))
                            {
                                parsedType += parseType(o, parsedType); 
                            }
                        }
                        else
                        {
                            //Object is not IEnumerable, process it
                            parsedType += parseType(fi.GetValue(obj), parsedType);
                        }
