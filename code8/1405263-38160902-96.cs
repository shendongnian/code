    public void OnMouseDown()
     {
     if (myType == .Green)
      manager.SpawnThreeGold(transform.position);
     if (myType == .Gold)
      manager.SpawnOneBlack(transform.position);
     Destroy(gameObject);
     }
