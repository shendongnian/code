    public GameObject GetEnemy(int n)
    {
        return enemies.get(n); // Gets the n enemy in your array
    }
    ...
    Enemy1bluespawner.GetComponent<Enemy1Spawner>().startEnemy1blueSpawner(); // Enemy blue spawner
    GameObject enemy = Enemy1bluespawner.GetComponent<Enemy1Spawner>().GetEnemy(0);
    enemy.GetComponent<Enemyblue1shooting>().startEBulleteFire();
