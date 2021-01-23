    interface IGameCharacter
    {
      ICollection<IWeapon> Weapons {get;}
      ICollection<IGameCharacter> Party {get;}
    }
