    public BasicType Save()
    {
         BasicType b = DataContext.Save(this); //Returns a BasicType
         return (BasicType)Activator.CreateInstance(this.GetType(), b);
    }
