    class Monster
    {
        enum States { NotInitialized, Dead, Normal, EnergyMax, ... }
        States _state;
        float _energy;
        void Update()
        {
            _energy += Random.Range(0f, 1f);
            switch(_state)
            {
                case States.Normal:
                    if(_energy > EnergyMax)
                    {
                        DoSomething(); // called once when energy become max
                        _state = States.EnergyMax;
                    }
                    break;
                ...
            }
        }
        ...
    }
