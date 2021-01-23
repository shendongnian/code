    var totalDamagePerCharacter = characters.Select(c => new
    {
        Character = c,
        TotalDamage = c.Inventory.Sum(item => item.Damage)
    })
    .ToList();
