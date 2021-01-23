    public override bool Equals(object obj)
    {
        BaseCharacter that = (BaseCharacter)obj;
        return this.IsDead == that.IsDead
            && this.Health.CurrentHealth == that.Health.CurrentHealth;
    }
