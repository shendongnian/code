    public Humanoid(Race race, Gender gender, string firstname, string lastname = null)
    {
        this.Limbs.Add(new Leg());
        this.Limbs.Add(new Leg());
        this.Limbs.Add(new Torso());
        this.Limbs.Add(new Arm());
        this.Limbs.Add(new Arm());
        this.Limbs.Add(new Head
            {
                // as an added exercise, how would you extend this concept to the Head object?
            });
    }
