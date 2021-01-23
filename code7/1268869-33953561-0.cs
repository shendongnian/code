    class Monster
    {
        private Action _doSomething;
        public Monster()
        {
            _doSomething = DoSomething;
        }
        float energy = 0.0f;
        void Update()
        {
            energy += Random.Range(0f, 1f);
            if (energy > 100.0f)
                if (_doSomething != null)
                    _doSomething();
        }
        void DoSomething() 
        {
            // logic...
            _doSomething = null;
        }
    }
