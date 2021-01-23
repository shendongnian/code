        internal sealed class ActorState
        {
            [DataMember]
            public List<string> PartitionNames { get; set; }
            [DataMember]
            public Dictionary<string, DateTime> PartitionLeases { get; set; }
            private IActorStateManager stateManager;
            internal static ActorState GetState(IActorStateManager stateManager)
            {                
               var state = stateManager.GetStateAsync<ActorState>("MyState").GetAwaiter().GetResult();
                state.stateManager = stateManager;
                return state;
            }
            internal void Save()
            {
                stateManager.AddOrUpdateStateAsync<ActorState>("MySate", this, (k,v) => this ).GetAwaiter();
            }
        }
