    public abstract class AMovementState : IState<MovementData> {
        public abstract M EnterState<M>
        (InputData inputData, MovementData movementData);
        M IState<MovementData>.EnterState<M> 
        (InputData inputData, MovementData movementData)
        {
          this.EnterState<M>(inputData, movementData);
        }
    }
