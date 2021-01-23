    /**Methods are from mscorlib.dll**/
        public virtual void Write(string value)
                {
                    if (value != null)
                    {
                        this.Write(value.ToCharArray());
                    }
                }
