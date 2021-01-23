    public override bool Equals(object obj)
    {
        Dollar dollar = (Dollar) obj; 
        return amount == dollar.amount;
    }
    public override int GetHashCode()
    {
        return amount.GetHashCode();
    }
