    if (entities[j] is Ore)
    { 
      pilots[i].Ship.InventoryAdd(entities[j]); entities.RemoveAt(j--); 
    }
    else if (entities[j] is Enemy)
    {
        if(entities[j] is Asteroid)
        {
            pilots[i].Ship.AddForce(entities[j].Force * (entities[j] as Enemy).Damage);
            pilots[i].Ship.HP -= (entities[j] as Enemy).Damage;
            entities.RemoveAt(j);
        }
    }
