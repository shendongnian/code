    public Create(string aName, int aHealth, int aMSpeed, Role aRole, Speciality aSpeciality)
    {
        this.NameCheck = aName;
        this.health = aHealth;
        this.mSpeed = aMSpeed;
        this.role = aRole;
        this.speciality = aSpeciality;
        Characters = new List<Create>();
    }
