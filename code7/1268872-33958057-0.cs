    class Monster {
        float energy = 0.0f;
        Action onUpdate;
        public Monster()
        {
            onUpdate = DoSomething;
        }
        void Update()
        {
            onUpdate();
        }
        void DoSomething()
        {
            energy += Random.Range(0f, 1f);
            if(energy > 100.0f)
            {
                // whatever you need to do
            }
            onUpdate = () => {};
        }
    }
