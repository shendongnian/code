    ///<summary>
    ///blah blah blah
    ///</summary>
    ///<returns>whether the hero is alive</returns>
    public bool KillMonster(Monster m) {
        if (!this.IsRunningAway)
        {
            if(this.AttackSpeed > m.AttackSpeed)
            {
                m.takesDamage(this.attackValue());
                if (m.isAlive())
                {
                    this.takesDamage(m.AttackValue);
                }
            }
            else if(this.AttackSpeed < m.AttackSpeed)
            {
                this.takesDamage(m.AttackValue);
                if (this.isAlive())
                {
                    m.takesDamage(this.attackValue());
                }
            }
            else
            {
                this.takesDamage(m.AttackValue);
                m.takesDamage(this.attackValue());
            }
        }
        else
        {
            if(this.AttackSpeed <= m.AttackSpeed)
            {
                this.takesDamage(m.AttackValue);
            }              
        }
        this.IsRunningAway = false;
        return this.isAlive();
    }
