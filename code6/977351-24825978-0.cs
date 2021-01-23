            if ((type.Flags & TypeFlags.Serializable) == TypeFlags.Serializable)
            {
                var problem = new Problem(GetResolution(type.BaseType.FullName, type.FullName), type.SourceContext);
                Problems.Add(problem);
            }
