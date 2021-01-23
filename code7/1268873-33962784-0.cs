    class Monster
        {
            float energy = 0.0f;
            DoSomethingState state;
    
            public Monster()
            {
                this.state = new DoSomethingStateNotCalled(this);
            }
    
            public void Update()
            {
                energy += Random.Range(0f, 1f);
                this.state.Update();
            }
    
            public void DoSomething() {
                System.Diagnostics.Debug.Write("done something");
            }
    
            public float GetEnergy() {
                return this.energy;
            }
    
            public void SetState(DoSomethingState state) {
                this.state = state;
            }
        }
    
    abstract class DoSomethingState {
    	
    	    protected Monster Monster;
    	
    	    public DoSomethingState(Monster monster) {
    		    this.Monster = monster;
    	    }
    	
    	    public abstract void Update();
        }
    
    class DoSomethingStateCalled : DoSomethingState
        {
            public DoSomethingStateCalled(Monster monster)
                : base(monster)
            {
            }
    
            public override void Update()
            {
            }
        }
    
     class DoSomethingStateNotCalled : DoSomethingState
        {
            public DoSomethingStateNotCalled(Monster monster)
                : base(monster)
            {
            }
    
            public override void Update()
            {
                if (this.Monster.GetEnergy() > 100.0f)
                {
                    this.Monster.DoSomething();
                    this.Monster.SetState(new DoSomethingStateCalled(this.Monster));
                }
            }
        }
