    public abstract class AMovementState : IState<MovementData> {
        public abstract M EnterState<M>
        (InputData inputData, MovementData movementData);
        M IState<MovementData>.EnterState<M> 
        (InputData inputData, MovementData movementData)
        where M : IState<MovementData>
        {
          this.EnterState<M>(inputData, movementData);
        }
    }
