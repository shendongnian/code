    class Column 
    {
        bool Equals(object other) 
        {
            // ...
            // skip further checks for simplicity
            // ...
            Column o = (Column) other;
            return o.Name == this.Name && o.Type == this.Type  ;
        }
    }
