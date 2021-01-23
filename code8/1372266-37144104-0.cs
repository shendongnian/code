    private void CheckForDestructables(Collider2D c)
    {
      this.Print("CheckForDestructables Called");
      string attackName = GetCurrentAttackName();
      AttackParams currentAttack = GetCurrentAttack(attackName);
      D.assert(currentAttack != null);
      this.Print("CheckForDestructables Called");
      
      if (currentAttack.IsAttacking && c.gameObject.tag == "Destructable")
      {
        List<BaseDestructibleScript> s = c.GetComponents<BaseDestructibleScript>().ToList();
    
        D.assert(s.Any(), "Could Not find child of type BaseDestructibleScript");
    
        for (int i = 0; i < s.Count(); i++)
        {
          s[i].onCollision(Movement.gameObject);
        }
      }
    }
