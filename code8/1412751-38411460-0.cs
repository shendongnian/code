    public class RecordVm 
            {
                public int Id { get; set; }
                public string Description { get; set; }
                public State State {
                    get { return this._state; }
                    set { this._state = value;
                        if (value == State.InProgress)
                            this.InProgress = true;return;
                        this.InProgress = false; }
                }
                private State _state;
                public bool IsCompeleted { get; set; }
    
                public bool InProgress { get; private set; }
    
             
            }
