    Collection<Variable> variables;
    public Collection<Variable> Variables
        {
            get
            {
                if (this.variables == null)
                {
                    this.variables = new Collection<Variable>();
                }
                return this.variables;
            }
        }
