     public override bool Equals(object obj)
            {
                if (!(obj as bool))
                {
                    return false;
                }
                return this == (bool)obj;
            }
