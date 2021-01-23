    using System;
    using Unity.Engine;
    public Vector2 SpawnLocation;
    public GameObject BasketBall;
    public class BasketBallSpawner : MonoBehavior
    {
        public void Update()
        {
            if (needToSpawnBall) spawnBall();
        }
        public void spawnBall()
        {
            GameObject basketBall = Instantiate(BasketBall, SpawnLocation, 0);
        }
    }
