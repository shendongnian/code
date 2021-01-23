    private EnemyFighter DuplicateEnemy(EnemyFighter original){
        var newEnemy = new EnemyFighter(){
            Name = original.Name
        };
        newEnemy.setLevel(original.Level);
        return newEnemy;
    }
    EnemyGroups.Add(new EnemyFighter[] { DuplicateEnemy(Enemies[1]) }); // Beaver
    EnemyGroups.Add(new EnemyFighter[] { DuplicateEnemy(Enemies[1]), DuplicateEnemy(Enemies[1]) }); // Beaver x2
    EnemyGroups.Add(new EnemyFighter[] { DuplicateEnemy(Enemies[2]) }); // Unicorn
